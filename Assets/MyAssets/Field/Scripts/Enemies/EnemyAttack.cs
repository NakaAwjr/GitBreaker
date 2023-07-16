using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Enemies
{
    public class EnemyAttack : BaseEnemyComponent
    {
        protected override void OnInitialize()
        {
            Observable.Timer(System.TimeSpan.Zero, System.TimeSpan.FromSeconds(5))
                .Subscribe(x =>
                    {
                        EnemyCore.CurrentEnemyGear.Value.EnemyWeapon.AttackNormal(EnemyCore.CurrentEnemyParameter);
                    }
                ).AddTo(this);

        }
    }
}
