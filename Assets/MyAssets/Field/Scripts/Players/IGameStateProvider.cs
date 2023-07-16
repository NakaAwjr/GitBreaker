using Assets.MyAssets.Field.Scripts.GameManagers;
using UniRx;

namespace Assets.MyAssets.Field.Scripts.Players
{
    /// <summary>
    /// ゲームの状態を通知するインターフェース
    /// </summary>
    public interface IGameStateProvider
    {
        IReadOnlyReactiveProperty<GameState> CurrentGameState { get; }
    }
}