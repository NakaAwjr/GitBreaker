using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Enemies
{
    public class EnemyAttack : BaseEnemyComponent
    {
        [SerializeField]
        private EnemyCollision _enemyCollision;
        
        protected override void OnInitialize()
        {
            Observable.Timer(System.TimeSpan.Zero, System.TimeSpan.FromSeconds(5))
                .Where(_ => _enemyCollision.CanAttack)
                .Subscribe(_ =>
                    {
                        EnemyCore.CurrentEnemyGear.Value.EnemyWeapon.AttackNormal(EnemyCore.CurrentEnemyParameter);
                    }
                ).AddTo(this);

        }
    }
}
