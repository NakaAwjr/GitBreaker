using System;
using System.Collections.Generic;
using System.Linq;
using Assets.MyAssets.Field.Scripts.Damages;
using Assets.MyAssets.Field.Scripts.GameManagers;
using Assets.MyAssets.Field.Scripts.Items;
using Assets.MyAssets.Field.Scripts.Items.Impless;
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

        public IReadOnlyReactiveProperty<GameState> CurrentGameState => _gameStateProvider.CurrentGameState;

        [SerializeField]
        private CharacterStates _defaultPlayerParameter;

        [SerializeField]
        private PlayerGear _defaultGear;

        private ReactiveDictionary<string, int> _currentPlayerParameter = new ReactiveDictionary<string, int>();
        public ReactiveDictionary<string, int> CurrentPlayerParameter => _currentPlayerParameter;
        
        private ReactiveProperty<bool> _isAlive = new BoolReactiveProperty(true);
        public IReadOnlyReactiveProperty<bool> IsAlive => _isAlive;

        private readonly AsyncSubject<CharacterStates> _onInitializeAsyncSubject = new AsyncSubject<CharacterStates>();
        public IObservable<CharacterStates> OnInitializeAsync => _onInitializeAsyncSubject;
        
        private Subject<ItemEffect> _pickUpItemSubject = new Subject<ItemEffect>();
        public IObservable<ItemEffect> OnPickUpItem => _pickUpItemSubject;
        
        private ReactiveProperty<PlayerGear> _currentPlayerGear = new ReactiveProperty<PlayerGear>();
        public IReadOnlyReactiveProperty<PlayerGear> CurrentPlayerGear => _currentPlayerGear;
        
        private Subject<Damage> _damageSubject = new Subject<Damage>();
        public IObservable<Damage> OnDamaged { get { return _damageSubject; } }

        void Awake()
        {
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
                    
                    EquipGear(_defaultGear);
                    
                    _currentPlayerParameter.ObserveReplace()
                        .Where(y => y.Key == "Hp" && y.NewValue <= 0)
                        .Subscribe(_ =>
                        {
                            _isAlive.Value = false;
                        });
                    
                    IsAlive.Where(y => !y)
                        .Subscribe(_ => Destroy(this.gameObject));
                });             
            
            this.OnTriggerEnter2DAsObservable()
                .Where(__ => IsAlive.Value)
                .Subscribe(x =>
                {
                    var i = x.GetComponent<ItemBase>();
                    if (i != null)
                    {
                        _pickUpItemSubject.OnNext(i.ItemEffect);
                        i.PickedUp();
                    }
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
        
        public void AddPlayerParameter(CharacterStates parameters)
        {
            _currentPlayerParameter["Hp"] += parameters.Hp;
            _currentPlayerParameter["Power"] += parameters.Power;
            _currentPlayerParameter["Defence"] += parameters.Defence;
            _currentPlayerParameter["MagicPoint"] += parameters.MagicPoint;
            _currentPlayerParameter["MagicPower"] += parameters.MagicPower;
            _currentPlayerParameter["MagicDefence"] += parameters.MagicDefence;
            _currentPlayerParameter["Speed"] += parameters.Speed;
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
        
        public void InitializePlayer(PlayerId id, IGameStateProvider gameStateProvider)
        {
            _playerId = id;
            _gameStateProvider = gameStateProvider;
            _onInitializeAsyncSubject.OnNext(_defaultPlayerParameter);
            _onInitializeAsyncSubject.OnCompleted();
        }
    }
}
