using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.States
{
    [CreateAssetMenu(menuName = "ScriptableObjects/CharacterStates")]
    public class CharacterStates : ScriptableObject
    {
        [SerializeField]
        private string _name = "";
        public string Name => _name;
        
        [SerializeField]
        private int _hp = 0;
        public int Hp => _hp;
        
        [SerializeField]
        private int _power = 0;
        public int Power => _power;
        
        [SerializeField]
        private int _defence = 0;
        public int Defence => _defence;

        [SerializeField]
        private int _magicPoint = 0;
        public int MagicPoint => _magicPoint;
        
        [SerializeField]
        private int _magicPower = 0;
        public int MagicPower => _magicPower;
        
        [SerializeField]
        private int _magicDefence = 0;
        public int MagicDefence => _magicDefence;
        
        [SerializeField]
        private int _speed = 0;
        public int Speed => _speed;

        /// <summary>
        /// 基本的に装備などによって変化しない値HPとMPを0にするメソッド
        /// </summary>
        public void SetFixValue()
        {
            this._hp = 0;
            this._magicPoint = 0;
        }

        public void AddValue(CharacterStates addStates)
        {
            this._hp += addStates.Hp;
            this._power += addStates.Power;
            this._defence += addStates.Defence;
            this._magicPoint += addStates.MagicPoint;
            this._magicPower += addStates.MagicPower;
            this._magicDefence += addStates.MagicDefence;
            this._speed += addStates._speed;
        }
        
        public void SetValue(int hp = 0,int power = 0, int defence = 0, int magicPoint = 0, int magicPower = 0, int magicDefence = 0, int speed = 0)
        {
            this._hp += hp;
            this._power += power;
            this._defence += defence;
            this._magicPoint += magicPoint;
            this._magicPower += magicPower;
            this._magicDefence += magicDefence;
            this._speed += speed;
        }
    }
}