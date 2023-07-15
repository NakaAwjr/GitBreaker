using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.States;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Weapons.Imples
{
    public class MagicWand : BaseWeapon
    {
        private GameObject _magicWandPrefab;

        private bool _recoveryWeapon;
        
        void Start()
        {
            _magicWandPrefab = Resources.Load("Prefabs/MagicWand") as GameObject;
            this.WeaponType = WeaponType.Sword;
            this.Power = 5;
            this.RecoverySecond = 0.7f;
            _recoveryWeapon = false;
        }
        
        protected override CharacterStates AttackNormal(CharacterStates currentStates)
        {
            if (_recoveryWeapon)
            {
                return currentStates;
            }

            StartCoroutine(RecoveryCoroutine());
            
            return currentStates;
        }
        
        protected override CharacterStates AttackSpecial(CharacterStates currentStates)
        {
            if (_recoveryWeapon)
            {
                return currentStates;
            }
            
            StartCoroutine(RecoveryCoroutine());
            
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