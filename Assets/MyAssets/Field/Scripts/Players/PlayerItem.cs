using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.Items;
using UnityEngine;
using UniRx;

namespace Assets.MyAssets.Field.Scripts.Players
{
    /// <summary>
    /// プレイヤーのアイテム処理
    /// </summary>
    public class PlayerItem : BasePlayerComponent
    {
        private float _pickUpWaitSeconds = 0.2f;
        private bool _pickUp;
        
        protected override void OnInitialize()
        {
            _pickUp = true;
            PlayerCore.OnPickUpItem
                .Where(_ => _pickUp)
                .Subscribe(item =>
                {
                    ChangePlayerStatus(item);
                    StartCoroutine(PickUpCoroutine());
                });
        }
        
        private void ChangePlayerStatus(ItemEffect item)
        {
            PlayerCore.AddPlayerParameter(item.UpStates);
        }

        private IEnumerator PickUpCoroutine()
        {
            _pickUp = false;
            yield return new WaitForSeconds(_pickUpWaitSeconds);
            _pickUp = true;
        }
    }
}
