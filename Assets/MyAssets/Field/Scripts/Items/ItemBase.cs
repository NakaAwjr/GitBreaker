using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Items.Impless
{
    public abstract class ItemBase : MonoBehaviour
    {
        [SerializeField]
        protected ItemEffect _itemEffect;

        public ItemEffect ItemEffect
        {
            get { return _itemEffect; }
        }

        public virtual void PickedUp()
        {
            Destroy(gameObject);
        }
    }
}


