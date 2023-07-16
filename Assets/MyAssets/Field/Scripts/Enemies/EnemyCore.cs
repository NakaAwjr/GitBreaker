using System;
using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.Damages;
using Assets.MyAssets.Field.Scripts.Enemies;
using Assets.MyAssets.Field.Scripts.States;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Enemies
{
    public class EnemyCore : MonoBehaviour
    {
        private EnemyType _enemyType;
        public EnemyType EnemyType => _enemyType;
        
        [SerializeField]
        private CharacterStates _defaultEnemyParameter;
        
        private ReactiveDictionary<string, int> _currentEnemyParameter;
        public ReactiveDictionary<string, int> CurrentEnemyParameter => _currentEnemyParameter;
        
        private ReactiveProperty<bool> _isAlive = new BoolReactiveProperty(true);
        public IReadOnlyReactiveProperty<bool> IsAlive => _isAlive;

        private readonly AsyncSubject<CharacterStates> _onInitializeAsyncSubject = new AsyncSubject<CharacterStates>();
        public IObservable<CharacterStates> OnInitializeAsync => _onInitializeAsyncSubject;
        
        private ReactiveProperty<EnemyGear> _currentEnemyGear = new ReactiveProperty<EnemyGear>();
        public IReadOnlyReactiveProperty<EnemyGear> CurrentEnemyGear => _currentEnemyGear;
        
        private Subject<Damage> _damageSubject = new Subject<Damage>();
        public IObservable<Damage> OnDamaged { get { return _damageSubject; } }

        void Awake()
        {
            OnDamaged.Where(x => 0 < x.AttackValue - _currentEnemyParameter["Defence"])
                .Subscribe(x =>
                {
                    _currentEnemyParameter["Hp"] -= x.AttackValue - _currentEnemyParameter["Defence"];
                });
            
            _onInitializeAsyncSubject
                .Subscribe(x =>
                {
                    _currentEnemyParameter = new ReactiveDictionary<string,int>()
                    {
                        {"Hp", x.Hp}, 
                        {"Power", x.Power}, 
                        {"Defence", x.Defence},
                        {"MagicPoint", x.MagicPoint},
                        {"MagicPower", x.MagicPower},
                        {"MagicDefence", x.MagicDefence},
                        {"Speed", x.Speed}
                    };
                    
                    IsAlive.Where(y => y).Skip(1)
                        .Subscribe(_ => { Debug.Log("いくぞ！"); });
                });             
        }
        
        public void DealDamage(Damage damage)
        {
            _damageSubject.OnNext(damage);
        }

        public void ResetEnemyParameter()
        {
            _currentEnemyParameter["Hp"] = _defaultEnemyParameter.Hp;
            _currentEnemyParameter["Power"] = _defaultEnemyParameter.Power;
            _currentEnemyParameter["Defence"] = _defaultEnemyParameter.Defence;
            _currentEnemyParameter["MagicPoint"] = _defaultEnemyParameter.MagicPoint;
            _currentEnemyParameter["MagicPower"] = _defaultEnemyParameter.MagicPower;
            _currentEnemyParameter["MagicDefence"] = _defaultEnemyParameter.MagicDefence;
            _currentEnemyParameter["Speed"] = _defaultEnemyParameter.Speed;
        }
        
        public void SetEnemyParameter(CharacterStates parameters)
        {
            _currentEnemyParameter["Hp"] = parameters.Hp;
            _currentEnemyParameter["Power"] = parameters.Power;
            _currentEnemyParameter["Defence"] = parameters.Defence;
            _currentEnemyParameter["MagicPoint"] = parameters.MagicPoint;
            _currentEnemyParameter["MagicPower"] = parameters.MagicPower;
            _currentEnemyParameter["MagicDefence"] = parameters.MagicDefence;
            _currentEnemyParameter["Speed"] = parameters.Speed;
        }

        public void EquipGear(EnemyGear gear)
        {
            CharacterStates enemyGear = ScriptableObject.CreateInstance<CharacterStates>();
            _currentEnemyGear.Value = gear;
            /*enemyGear.AddValue(gear.Head);
            enemyGear.AddValue(gear.Body);
            enemyGear.AddValue(gear.Legs);*/
            enemyGear.SetValue(hp:CurrentEnemyParameter["Hp"],magicPoint:CurrentEnemyParameter["MagicPoint"]);
            SetEnemyParameter(enemyGear);
        }
        
        public void InitializeEnemy()
        {
            _onInitializeAsyncSubject.OnNext(_defaultEnemyParameter);
            _onInitializeAsyncSubject.OnCompleted();
        }
    }
}
