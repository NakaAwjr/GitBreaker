using System;
using System.Collections.Generic;
using System.Linq;
using Assets.MyAssets.Field.Scripts.States;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Players
{
    public class PlayerCore : MonoBehaviour
    {
        private PlayerId _playerId;
        public PlayerId PlayerId => _playerId;
        
        private IGameStateProvider _gameStateProvider;
        
        /*private Subject<Damage> _damageSubject = new Subject<Damage>();
        public IObservable<Damage> OnDamaged { get { return _damageSubject; } }*/
        
        [SerializeField]
        private CharacterStates _defaultPlayerParameter;

        private ReactiveDictionary<string, int> _currentPlayerParameter;
        public Dictionary<string, int> CurrentPlayerParameter => _currentPlayerParameter.ToDictionary(pair => pair.Key, pair => pair.Value);
        public IObservable<DictionaryReplaceEvent<string, int>> ReplaceObservable => _currentPlayerParameter.ObserveReplace();

        void Awake()
        {
            _currentPlayerParameter = new ReactiveDictionary<string,int>()
            {
                {"Hp", _defaultPlayerParameter.Hp}, 
                {"Power", _defaultPlayerParameter.Power}, 
                {"Defence", _defaultPlayerParameter.Defence},
                {"MagicPoint", _defaultPlayerParameter.MagicPoint},
                {"MagicPower", _defaultPlayerParameter.MagicPower},
                {"MagicDefence", _defaultPlayerParameter.MagicDefence},
                {"Speed", _defaultPlayerParameter.Speed}
            };
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
            CharacterStates playerGear = ScriptableObject.CreateInstance<CharacterStates>();;
            playerGear.AddValue(gear.Head);
            playerGear.AddValue(gear.Body);
            playerGear.AddValue(gear.Legs);
            playerGear.SetValue(hp:CurrentPlayerParameter["Hp"],magicPoint:CurrentPlayerParameter["MagicPoint"]);
            SetPlayerParameter(playerGear);
        }
    }
}
