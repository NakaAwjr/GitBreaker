using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.Attacks;
using Assets.MyAssets.Field.Scripts.Attacks.Attackers;
using Assets.MyAssets.Field.Scripts.States;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Weapons.Imples
{
    public class MagicWand : BaseWeapon
    {
        private GameObject _magicWandPrefab;

        private bool _recoveryWeapon;
        
        private float _specialMagnification = 1.5f;
        
        [SerializeField]
        private GameObject _attackRange;

        private int _decreaseValue = 2;
        
        void Start()
        {
            _magicWandPrefab = Resources.Load("Prefabs/MagicWand") as GameObject;
            this.WeaponType = WeaponType.MagicWand;
            this.Power = 5;
            this.RecoverySecond = 1.7f;
            _recoveryWeapon = false;
        }
        
        public override ReactiveDictionary<string, int> AttackNormal(ReactiveDictionary<string, int> currentStates)
        {
            if (!_recoveryWeapon)
            {
                var attack = Instantiate(_attackRange, this.transform.position, this.transform.rotation)
                    .GetComponentInChildren<BaseAttack>();
                attack.StartAttack(Power + currentStates["Power"], new PlayerAttacker());
                currentStates["MagicPoint"] -= _decreaseValue; 
                StartCoroutine(RecoveryCoroutine());
                return currentStates;
            }

            
            return currentStates;
        }
        
        public override ReactiveDictionary<string, int> AttackSpecial(ReactiveDictionary<string, int> currentStates)
        {
            if (!_recoveryWeapon)
            {
                var physicsAttack = Instantiate(_attackRange, this.transform.position, this.transform.rotation)
                    .GetComponentInChildren<BaseAttack>();
                physicsAttack.StartAttack((int)(Power * _specialMagnification) + currentStates["Power"], new PlayerAttacker());
                currentStates["MagicPoint"] -= (int)(_decreaseValue * _specialMagnification);
                StartCoroutine(RecoveryCoroutine());
                return currentStates;
            }

            return currentStates;
        }

        IEnumerator RecoveryCoroutine()
        {
            _recoveryWeapon = true;
            yield return new WaitForSeconds(RecoverySecond);
            _recoveryWeapon = false;
        }
    }
}