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
                    Debug.Log(PlayerCore.CurrentPlayerGear.Value.PlayerWeapon);
                    if (PlayerCore.CurrentPlayerGear.Value.PlayerWeapon != null)
                    {
                        ReactiveDictionary<string, int> afterStates = PlayerCore.CurrentPlayerGear.Value.PlayerWeapon.AttackNormal(PlayerCore.CurrentPlayerParameter);
                        CharacterStates afterParameter = new CharacterStates();
                        afterParameter.SetValue(
                            hp:afterStates["Hp"],
                            power:afterStates["Power"],
                            defence:afterStates["Defence"],
                            magicPoint:afterStates["MagicPoint"],
                            magicPower:afterStates["MagicPower"],
                            magicDefence:afterStates["MagicDefence"]
                            ,speed:afterStates["Speed"]
                        );
                    
                        PlayerCore.SetPlayerParameter(afterParameter);
                    }
                });
            
            InputProvider.OnSpecialAttackButtonPushed
                .Where(_ => PlayerCore.IsAlive.Value)
                .Subscribe(_ =>
                {
                    if (PlayerCore.CurrentPlayerGear.Value.PlayerWeapon != null)
                    {
                        ReactiveDictionary<string, int> afterStates =
                            PlayerCore.CurrentPlayerGear.Value.PlayerWeapon.AttackSpecial(PlayerCore
                                .CurrentPlayerParameter);
                        CharacterStates afterParameter = new CharacterStates();

                        afterParameter.SetValue(
                            hp: afterStates["Hp"],
                            power: afterStates["Power"],
                            defence: afterStates["Defence"],
                            magicPoint: afterStates["MagicPoint"],
                            magicPower: afterStates["MagicPower"],
                            magicDefence: afterStates["MagicDefence"]
                            , speed: afterStates["Speed"]
                        );

                        PlayerCore.SetPlayerParameter(afterParameter);
                    }
                });
        }
    }
}
