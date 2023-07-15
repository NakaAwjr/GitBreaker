using System;
using Assets.MyAssets.Field.Scripts.States;

namespace Assets.MyAssets.Field.Scripts.Players
{
    [Serializable]
    public struct PlayerGear
    {
        public CharacterStates Head;
        public CharacterStates Body;
        public CharacterStates Legs;
        //public Weapon PlayerWeapon;
    }
}