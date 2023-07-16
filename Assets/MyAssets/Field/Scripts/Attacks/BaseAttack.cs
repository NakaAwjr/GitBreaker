using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Attacks
{
    public abstract class BaseAttack : MonoBehaviour
    {
        public IAttacker Attacker { get; set; }

        protected float AttackPower { get; set; }
    }
}
