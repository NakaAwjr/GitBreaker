using System;
using Assets.MyAssets.Field.Scripts.Damages;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Attacks.Imples
{
    public class PhysicsAttack : BaseAttack
    {
        private float _hitEffectDuration = 0.1f;
        private int _attackPower;
        
        public override void StartAttack(int attackPower, IAttacker attacker)
        {
            _attackPower = attackPower;
            this.Attacker = attacker;
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

