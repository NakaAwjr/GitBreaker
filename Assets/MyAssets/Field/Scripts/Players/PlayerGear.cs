using System;
using Assets.MyAssets.Field.Scripts.States;
using Assets.MyAssets.Field.Scripts.Weapons;

namespace Assets.MyAssets.Field.Scripts.Players
{
    /// <summary>
    /// プレイヤーの装備
    /// </summary>
    [Serializable]
    public struct PlayerGear
    {
        public CharacterStates Head;
        public CharacterStates Body;
        public CharacterStates Legs;
        public BaseWeapon PlayerWeapon;
    }
}