using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.States
{
    [CreateAssetMenu(menuName = "ScriptableObjects/CharacterStates")]
    public class CharacterStates : ScriptableObject
    {
        public int Hp;
        public int Power;
        public int Defence;
        public int MagicPoint;
        public int MagicPower;
        public int MagicDefence;
        public int Speed;
    }
}