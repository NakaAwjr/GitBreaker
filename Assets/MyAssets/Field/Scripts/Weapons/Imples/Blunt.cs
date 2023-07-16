using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.Attacks;
using Assets.MyAssets.Field.Scripts.Attacks.Attackers;
using Assets.MyAssets.Field.Scripts.Players;
using Assets.MyAssets.Field.Scripts.States;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Weapons.Imples
{
    public class Blunt : BaseWeapon
    {
        private GameObject _bluntPrefab;
        
        private bool _recoveryWeapon;

        private float _specialMagnification = 1.5f;
        
        [SerializeField]
        private GameObject _attackRange;
        
        void Start()
        {
            _bluntPrefab = Resources.Load("Prefabs/Blunt") as GameObject;
            this.WeaponType = WeaponType.Blunt;
            this.Power = 10;
            this.RecoverySecond = 2f;
            _recoveryWeapon = false;
        }
        
        public override ReactiveDictionary<string, int> AttackNormal(ReactiveDictionary<string, int> currentStates)
        {
            if (!_recoveryWeapon)
            {
                var attack = Instantiate(_attackRange, this.transform.position, this.transform.rotation)
                    .GetComponentInChildren<BaseAttack>();
                attack.StartAttack(Power + currentStates["Power"], new PlayerAttacker());
                StartCoroutine(RecoveryCoroutine());
                return currentStates;
            }

            return currentStates;
        }
        
        public override ReactiveDictionary<string, int> AttackSpecial(ReactiveDictionary<string, int> currentStates)
        {
            if (!_recoveryWeapon)
            {
                var attack = Instantiate(_attackRange, this.transform.position, this.transform.rotation)
                    .GetComponentInChildren<BaseAttack>();
                attack.StartAttack((int)(Power * _specialMagnification) + currentStates["Power"], new PlayerAttacker());
                currentStates["MagicPoint"]--; 
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
