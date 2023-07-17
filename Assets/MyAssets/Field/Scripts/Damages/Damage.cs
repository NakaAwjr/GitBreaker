//using Assets.MyAssets.Scripts.Attacks;
using System;
using Assets.MyAssets.Field.Scripts.Attacks;

namespace Assets.MyAssets.Field.Scripts.Damages
{
    /// <summary>
    /// ダメージの情報を表すクラス
    /// </summary>
    [Serializable]
    public struct Damage
    {
        public IAttacker Attacker;
        public int AttackValue;
    }
}