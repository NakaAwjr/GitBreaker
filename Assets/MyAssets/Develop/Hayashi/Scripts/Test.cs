using System.Collections;
using Assets.MyAssets.Field.Scripts.Attacks.Imples;
using Assets.MyAssets.Field.Scripts.Players;
using UnityEngine;
using UniRx;

public class Test : MonoBehaviour
{
    [SerializeField]
    private PlayerCore _playerCore;
    
    void Start()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerCore>().CurrentPlayerParameter.ObserveReplace()
            .Subscribe(x =>
            {
                //Debug.Log($"{x.Key}が{x.OldValue}から{x.NewValue}に変わったよ!");
            });
    }
}
