using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Enemies
{
    public abstract class BaseEnemyComponent : MonoBehaviour
    {
        protected EnemyCore EnemyCore;
        protected ReactiveDictionary<string, int> CurrentPlayerParameter => EnemyCore.CurrentEnemyParameter;
        
        private void Start()
        {
            EnemyCore = GetComponent<EnemyCore>();

            //Coreの情報が確定したら初期化を呼び出す
            EnemyCore.OnInitializeAsync.Subscribe(_ => OnInitialize());

            OnInitialize();
        }
        
        protected abstract void OnInitialize();//初期化処理
    }
}
