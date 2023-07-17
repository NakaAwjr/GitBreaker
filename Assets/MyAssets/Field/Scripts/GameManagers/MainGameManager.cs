using System;
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
        private EnemyManager _enemyManager;
        private Scene.Field _field;
        private PlayerCore _playerCore;

        void Start()
        {
            _playerProvider = GetComponent<PlayerProvider>();
            _timeManager = GetComponent<TimeManager>();
            _enemyManager = GetComponent<EnemyManager>();
            _field = GetComponent<Scene.Field>();

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
                    Ready();
                    break;
                case GameState.Search:
                    Search();
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
                _playerCore = _playerProvider.CreatePlayer(
                    PlayerId.Player1,
                    Vector3.zero,
                    this
                );
                
                yield return null;
                
                _currentState.Value = GameState.Ready;
            }

            void Ready()
            {
                _timeManager.ReadySecond
                    .FirstOrDefault(x => x == 0)
                    .Delay(TimeSpan.FromSeconds(1))
                    .Subscribe(_ => _currentState.Value = GameState.Search)
                    .AddTo(gameObject);
                _timeManager.StartGameReadyCountDown();
            }

            void Search()
            {
                _timeManager.SearchSecond
                    .FirstOrDefault(x => x == 0)
                    .Delay(TimeSpan.FromSeconds(2))
                    .Subscribe(_ => _currentState.Value = GameState.Finish);
                
                _enemyManager.IsAlive
                    .Where(x => !x)
                    .Subscribe(_ => _currentState.Value = GameState.Finish);
                _timeManager.StartBattleCountDown();
                _enemyManager.StartMonitorBoss();
            }

            void Finish()
            {
                Debug.Log($"{_enemyManager.KillEnemyCount}体");
                _field.SceneLoad(_enemyManager.IsAlive.Value,_playerCore.IsAlive.Value, _enemyManager.KillEnemyCount);
            }
        }
    }
}
