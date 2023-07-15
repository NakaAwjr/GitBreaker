using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.States
{
    [CreateAssetMenu(menuName = "ScriptableObjects/CharacterStates")]
    public class CharacterStates : ScriptableObject
    {
        [SerializeField]
        private int _hp;
        public int Hp => _hp;
        
        [SerializeField]
        private int _power;
        public int Power => _power;
        
        [SerializeField]
        private int _defence;
        public int Defence => _defence;

        [SerializeField]
        private int _magicPoint;
        public int MagicPoint => _magicPoint;
        
        [SerializeField]
        private int _magicPower;
        public int MagicPower => _magicPower;
        
        [SerializeField]
        private int _magicDefence;
        public int MagicDefence => _magicDefence;
        
        [SerializeField]
        private int _speed;
        public int Speed => _speed;
    }
}