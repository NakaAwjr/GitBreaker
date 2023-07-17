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

        private readonly ReactiveCollection<bool> _reactiveCollection = new ReactiveCollection<bool>();

        private int _killEnemyCount;
        public int KillEnemyCount => _killEnemyCount;

        public void StartMonitorBoss()
        {
            _killEnemyCount = 0;
            if (GameObject.FindWithTag("Boss").GetComponent<EnemyCore>() != null)
            {
                GameObject.FindWithTag("Boss").GetComponent<EnemyCore>().IsAlive
                    .Where(x => x == false)
                    .Subscribe(_ =>
                    {
                        _isAlive.Value = false;
                    });
            }

            var enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (var enemy in enemies)
            {
                Debug.Log("見つけた");
                enemy.GetComponent<EnemyCore>().IsAlive.Where(x => !x).Subscribe(_ => _killEnemyCount++);
            }
        }
    }
}
