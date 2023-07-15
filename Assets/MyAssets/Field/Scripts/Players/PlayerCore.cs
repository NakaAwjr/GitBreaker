using System;
using System.Collections.Generic;
using System.Linq;
using Assets.MyAssets.Field.Scripts.Damages;
using Assets.MyAssets.Field.Scripts.States;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Players
{
    /// <summary>
    /// プレイヤーの基本情報
    /// </summary>
    public class PlayerCore : MonoBehaviour, IDamageable
    {
        private PlayerId _playerId;
        public PlayerId PlayerId => _playerId;
        
        private IGameStateProvider _gameStateProvider;
        
        /*private Subject<Damage> _damageSubject = new Subject<Damage>();
        public IObservable<Damage> OnDamaged { get { return _damageSubject; } }*/
        
        [SerializeField]
        private CharacterStates _defaultPlayerParameter;

        private ReactiveDictionary<string, int> _currentPlayerParameter;
        public ReactiveDictionary<string, int> CurrentPlayerParameter => _currentPlayerParameter;
        
        private ReactiveProperty<bool> _isAlive = new BoolReactiveProperty(true);
        public IReadOnlyReactiveProperty<bool> IsAlive => _isAlive;

        private readonly AsyncSubject<CharacterStates> _onInitializeAsyncSubject = new AsyncSubject<CharacterStates>();
        public IObservable<CharacterStates> OnInitializeAsync => _onInitializeAsyncSubject;
        
        //private Subject<ItemEffect> _pickUpItemSubject = new Subject<ItemEffect>();
        //public IObservable<ItemEffect> OnPickUpItem => _pickUpItemSubject;
        
        private ReactiveProperty<PlayerGear> _currentPlayerGear;
        public IReadOnlyReactiveProperty<PlayerGear> CurrentPlayerGear => _currentPlayerGear;
        
        private Subject<Damage> _damageSubject = new Subject<Damage>();
        public IObservable<Damage> OnDamaged { get { return _damageSubject; } }

        void Awake()
        {
            InitializePlayer();
            
            OnDamaged.Where(x => 0 < x.AttackValue - _currentPlayerParameter["Defence"])
                .Subscribe(x =>
                {
                    _currentPlayerParameter["Hp"] -= x.AttackValue - _currentPlayerParameter["Defence"];
                });
            
            _onInitializeAsyncSubject
                .Subscribe(x =>
                {
                    _currentPlayerParameter = new ReactiveDictionary<string,int>()
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
            
            this.OnTriggerEnter2DAsObservable()
                .Where(__ => IsAlive.Value)
                .Subscribe(x =>
                {
                    /*var i = x.GetComponent<ItemBase>();
                    if (i != null)
                    {
                        _pickUpItemSubject.OnNext(i.ItemEffect);
                        i.ActivateEffect();
                    }*/
                });
        }
        
        public void DealDamage(Damage damage)
        {
            _damageSubject.OnNext(damage);
        }


        public void ResetPlayerParameter()
        {
            _currentPlayerParameter["Hp"] = _defaultPlayerParameter.Hp;
            _currentPlayerParameter["Power"] = _defaultPlayerParameter.Power;
            _currentPlayerParameter["Defence"] = _defaultPlayerParameter.Defence;
            _currentPlayerParameter["MagicPoint"] = _defaultPlayerParameter.MagicPoint;
            _currentPlayerParameter["MagicPower"] = _defaultPlayerParameter.MagicPower;
            _currentPlayerParameter["MagicDefence"] = _defaultPlayerParameter.MagicDefence;
            _currentPlayerParameter["Speed"] = _defaultPlayerParameter.Speed;
        }
        
        public void SetPlayerParameter(CharacterStates parameters)
        {
            _currentPlayerParameter["Hp"] = parameters.Hp;
            _currentPlayerParameter["Power"] = parameters.Power;
            _currentPlayerParameter["Defence"] = parameters.Defence;
            _currentPlayerParameter["MagicPoint"] = parameters.MagicPoint;
            _currentPlayerParameter["MagicPower"] = parameters.MagicPower;
            _currentPlayerParameter["MagicDefence"] = parameters.MagicDefence;
            _currentPlayerParameter["Speed"] = parameters.Speed;
        }

        public void EquipGear(PlayerGear gear)
        {
            CharacterStates playerGear = ScriptableObject.CreateInstance<CharacterStates>();
            _currentPlayerGear.Value = gear;
            playerGear.AddValue(gear.Head);
            playerGear.AddValue(gear.Body);
            playerGear.AddValue(gear.Legs);
            playerGear.SetValue(hp:CurrentPlayerParameter["Hp"],magicPoint:CurrentPlayerParameter["MagicPoint"]);
            SetPlayerParameter(playerGear);
        }
        
        public void InitializePlayer()
        {
            _onInitializeAsyncSubject.OnNext(_defaultPlayerParameter);
            _onInitializeAsyncSubject.OnCompleted();
        }
    }
}
