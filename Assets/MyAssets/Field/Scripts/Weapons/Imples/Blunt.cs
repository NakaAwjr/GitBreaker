using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.States;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Weapons.Imples
{
    public class Blunt : BaseWeapon
    {
        private GameObject _bluntPrefab;
        
        private bool _recoveryWeapon;
        
        void Start()
        {
            _bluntPrefab = Resources.Load("Prefabs/Blunt") as GameObject;
            this.WeaponType = WeaponType.Blunt;
            this.Power = 10;
            this.RecoverySecond = 1f;
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
