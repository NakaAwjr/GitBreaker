using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.States;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Weapons
{
    /// <summary>
    /// キャラクターの武器の基底クラス
    /// </summary>
    public abstract class BaseWeapon : MonoBehaviour
    {
        public WeaponType WeaponType;
        public int Power;
        public float RecoverySecond;

        public abstract ReactiveDictionary<string, int> AttackNormal(ReactiveDictionary<string, int> currentStates);
        public abstract ReactiveDictionary<string, int> AttackSpecial(ReactiveDictionary<string, int> currentStates);
    }
}

