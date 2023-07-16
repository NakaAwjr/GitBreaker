using System.Collections;
using Assets.MyAssets.Field.Scripts.Attacks.Imples;
using Assets.MyAssets.Field.Scripts.GameManagers;
using Assets.MyAssets.Field.Scripts.Players;
using UnityEngine;
using UniRx;

public class Test : MonoBehaviour
{
    [SerializeField]
    private TimeManager _timeManager;

    void Start()
    {
        _timeManager.ReadySecond.Subscribe(x =>
        {
            Debug.Log($"残り{x}");
        });
    }
}
