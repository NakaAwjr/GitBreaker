using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.GameManagers
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField]
        private IntReactiveProperty _readySecond = new IntReactiveProperty(3);

        [SerializeField]
        private IntReactiveProperty _searchSecond = new IntReactiveProperty(120);

        /// <summary>
        /// ゲーム開始前のカウントダウン
        /// </summary>
        public IReadOnlyReactiveProperty<int> ReadySecond => _readySecond;

        /// <summary>
        /// ゲームの残り時間
        /// </summary>
        public IReadOnlyReactiveProperty<int> SearchSecond => _searchSecond;


        /// <summary>
        /// レディカウントダウンを開始する
        /// </summary>
        public void StartGameReadyCountDown()
        {
            StartCoroutine(ReadyCountCoroutine());
        }

        IEnumerator ReadyCountCoroutine()
        {
            yield return new WaitForSeconds(0.5f);

            _readySecond.SetValueAndForceNotify(_readySecond.Value);

            yield return new WaitForSeconds(1);
            while (_readySecond.Value > 0)
            {
                _readySecond.Value -= 1;
                yield return new WaitForSeconds(1);
            }
        }

        /// <summary>
        /// 探索タイマーのカウントを開始する
        /// </summary>
        public void StartBattleCountDown()
        {
            StartCoroutine(BattleCountDownCoroutine());
        }

        IEnumerator BattleCountDownCoroutine()
        {
            while (_searchSecond.Value > 0)
            {
                yield return new WaitForSeconds(1);
                _searchSecond.Value--;
            }
        }

    }
}

