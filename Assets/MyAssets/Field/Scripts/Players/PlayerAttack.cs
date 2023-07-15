using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.States;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Players
{
    /// <summary>
    /// プレイヤーの攻撃
    /// </summary>
    public class PlayerAttack : BasePlayerComponent
    {
        protected override void OnInitialize()
        {
            InputProvider.OnNormalAttackButtonPushed
                .Where(_ => PlayerCore.IsAlive.Value)
                .Subscribe(_ =>
                {
                    /*CharacterStates afterStates = PlayerCore.CurrentPlayerGear.Value.Weapon.AttackNormal(PlayerCore.CurrentPlayerParameter);
                    PlayerCore.SetPlayerParameter(afterStates);*/
                });
            
            InputProvider.OnSpecialAttackButtonPushed
                .Where(_ => PlayerCore.IsAlive.Value)
                .Subscribe(_ =>
                {
                    /*CharacterStates afterStates = PlayerCore.CurrentPlayerGear.Value.Weapon.AttackSpecial(PlayerCore.CurrentPlayerParameter);
                    PlayerCore.SetPlayerParameter(afterStates);*/
                });
        }
    }
}
