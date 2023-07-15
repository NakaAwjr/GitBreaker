using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.States;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Weapons.Imples
{
    public class Sword : BaseWeapon
    {
        private GameObject _swordPrefab;
        
        private bool _recoveryWeapon;
        
        void Start()
        {
            _swordPrefab = Resources.Load("Prefabs/Sword") as GameObject;
            this.WeaponType = WeaponType.Sword;
            this.Power = 3;
            this.RecoverySecond = 0.5f;
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