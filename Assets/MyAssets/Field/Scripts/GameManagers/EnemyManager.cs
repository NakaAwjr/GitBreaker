using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.Enemies;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.GameManagers
{
    public class EnemyManager : MonoBehaviour
    {
        private ReactiveProperty<bool> _isAlive = new ReactiveProperty<bool>(true);
        public ReactiveProperty<bool> IsAlive => _isAlive;

        public void StartMonitorBoss()
        {
            GameObject.FindWithTag("Boss").GetComponent<EnemyCore>().IsAlive
                .Where(x => x == false)
                .Subscribe(_ =>
                {
                    _isAlive.Value = false;
                });
        }
    }
}
