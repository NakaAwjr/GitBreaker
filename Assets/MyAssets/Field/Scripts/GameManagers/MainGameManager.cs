using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.Players;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.GameManagers
{
    public class MainGameManager : MonoBehaviour,IGameStateProvider
    {
        private GameStateReactiveProperty _currentState = new GameStateReactiveProperty(GameState.Init);

        public IReadOnlyReactiveProperty<GameState> CurrentGameState => _currentState;

        private PlayerProvider _playerProvider;
        private TimeManager _timeManager;

        void Start()
        {
            _playerProvider = GetComponent<PlayerProvider>();
            _timeManager = GetComponent<TimeManager>();

            _currentState.Subscribe(state =>
            {
                OnStateChanged(state);
            });
        }

        void OnStateChanged(GameState nextState)
        {
            switch (nextState)
            {
                case GameState.Init:
                    StartCoroutine(InitCoroutine());
                    break;
                case GameState.Ready:
                    StartCoroutine(ReadyCoroutine());
                    break;
                case GameState.Search:
                    Search();
                    break;
                case GameState.Result:
                    Result();
                    break;
                case GameState.Finish:
                    Finish();
                    break;
                default:
                    break;
            }

            IEnumerator InitCoroutine()
            {
                //ここでプレイヤーの生成等行います。
                _playerProvider.CreatePlayer(
                    PlayerId.Player1,
                    Vector3.zero,
                    this
                );
                
                yield return null;
                
                _currentState.Value = GameState.Ready;
            }

            IEnumerator ReadyCoroutine()
            {
                yield break;
            }

            void Search()
            {
                
            }

            void Result()
            {
                
            }

            void Finish()
            {
                
            }
        }
    }
}
