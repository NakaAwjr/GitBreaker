using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Assets.MyAssets.Field.Scripts.Players
{
    /// <summary>
    /// プレイヤーのinput側からの動きの制御
    /// </summary>
    public class PlayerController : BasePlayerComponent
    {
        [SerializeField]
        private PlayerMove _playerMove;
        
        protected override void OnInitialize()
        {
            InputProvider.MoveDirection
                //.Where(_ => PlayerCore.CurrentGameState.Value == GameState.Battle)
                .Subscribe(x =>
                {
                    var value = (!PlayerCore.IsAlive.Value) ? Vector3.zero : x;
                    _playerMove.Move(value);
                });
        }
    }
}

