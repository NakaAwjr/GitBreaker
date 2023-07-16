using System;
using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.Damages;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Attacks.Imples
{
    public class MagicAttack : BaseAttack
    {
        private float _hitEffectDuration = 2f;
        private int _attackPower;

        private float _addPower = 500;

        [SerializeField]
        private Rigidbody2D _rigidBody2D;
        
        public override void StartAttack(int attackPower, IAttacker attacker)
        {
            _attackPower = attackPower;
            this.Attacker = attacker;
            
            _rigidBody2D.AddForce(transform.up * _addPower);
            
            this.UpdateAsObservable()
                .Delay(TimeSpan.FromSeconds(_hitEffectDuration))
                .FirstOrDefault()
                .Subscribe(_ => Destroy(gameObject));
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var damageApplicable = other.gameObject.GetComponent<IDamageable>();
            if (damageApplicable != null)
            {
                damageApplicable.DealDamage(CalcDamage());
                Destroy(gameObject);
            }
        }
        
        Damage CalcDamage()
        {
            return new Damage()
            {
                Attacker = this.Attacker,
                AttackValue = _attackPower
            };
        }
    }
}
