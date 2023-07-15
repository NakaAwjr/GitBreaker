using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.States;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Weapons
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        private WeaponType _weaponType;
        private int _power;
        private int _recoverySecond;

        protected abstract void AttackNormal(CharacterStates currentStates);
        protected abstract void AttackSpecial(CharacterStates currentStates);
    }
}

