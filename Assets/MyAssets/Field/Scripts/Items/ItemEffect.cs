using System;
using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.States;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Items
{
    [Serializable]
    public struct ItemEffect
    {
        public ItemType ItemType;
        public CharacterStates UpStates;
    }
}
