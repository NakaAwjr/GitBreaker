using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.States;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Weapons
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        public WeaponType WeaponType;
        public int Power;
        public float RecoverySecond;

        protected abstract CharacterStates AttackNormal(CharacterStates currentStates);
        protected abstract CharacterStates AttackSpecial(CharacterStates currentStates);
    }
}

