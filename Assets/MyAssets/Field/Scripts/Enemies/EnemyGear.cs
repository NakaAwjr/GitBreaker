using System;
using Assets.MyAssets.Field.Scripts.States;
using Assets.MyAssets.Field.Scripts.Weapons;

namespace Assets.MyAssets.Field.Scripts.Enemies
{
    [Serializable]
    public struct EnemyGear
    {
        public CharacterStates Head;
        public CharacterStates Body;
        public CharacterStates Legs;
        public BaseWeapon EnemyWeapon;
    }
}
