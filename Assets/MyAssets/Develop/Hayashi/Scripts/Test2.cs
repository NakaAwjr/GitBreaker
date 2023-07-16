using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.Damages;
using UnityEngine;

public class Test2 : MonoBehaviour,IDamageable
{
    public void DealDamage(Damage damage)
    {
        Debug.Log($"{damage.Attacker.GetType()}の攻撃！{damage.AttackValue}ダメージ！");
    }
}
