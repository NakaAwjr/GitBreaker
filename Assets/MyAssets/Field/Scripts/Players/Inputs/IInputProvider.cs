using UnityEngine;
using UniRx;

namespace Assets.MyAssets.Field.Scripts.Players.Inputs
{
    /// <summary>
    /// 入力に対するイベントのインターフェース
    /// </summary>
    public interface IInputProvider
    {
        public IReadOnlyReactiveProperty<Vector3> MoveDirection{ get; }
        public IReadOnlyReactiveProperty<bool> OnItemButtonPushed{ get; }
        public IReadOnlyReactiveProperty<bool> OnNormalAttackButtonPushed{ get; }
        public IReadOnlyReactiveProperty<bool> OnSpecialAttackButtonPushed{ get; }
    }
}
