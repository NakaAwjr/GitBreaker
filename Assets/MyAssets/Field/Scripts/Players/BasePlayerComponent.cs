using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.Players.Inputs;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.Players
{
    public abstract class BasePlayerComponent : MonoBehaviour
    {
        private IInputProvider _inputEventProvider;
        protected IInputProvider InputProvider => _inputEventProvider;

        protected PlayerCore PlayerCore;
        protected ReactiveDictionary<string, int> CurrentPlayerParameter => PlayerCore.CurrentPlayerParameter;
        
        private void Start()
        {
            _inputEventProvider = GetComponent<IInputProvider>();
            PlayerCore = GetComponent<PlayerCore>();

            //Coreの情報が確定したら初期化を呼び出す
            PlayerCore.OnInitializeAsync.Subscribe(_ => OnInitialize());

            OnInitialize();
        }
        
        protected abstract void OnInitialize();//初期化処理
    }
}
