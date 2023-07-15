using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Players
{
    public class PlayerItem : BasePlayerComponent
    {
        private Coroutine _currentCoroutine;
        
        protected override void OnInitialize()
        {
            /*
            PlayerCore.OnPickUpItem
                .Subscribe(item =>
                {
                    ChangePlayerStatus(item);
                });*/
        }
        
        /*private void ChangePlayerStatus(ItemEffect item)
        {
            PlayerCore.ResetPlayerParameter();

            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
            _currentCoroutine = StartCoroutine(ItemCoroutine(item));
        }

        private IEnumerator ItemCoroutine(ItemEffect item)
        {
            PlayerCore.SetPlayerParameter(item.PowerUpParameters);

            yield return new WaitForSeconds(item.DurationTime);

            PlayerCore.ResetPlayerParameter();
        }*/
    }
}
