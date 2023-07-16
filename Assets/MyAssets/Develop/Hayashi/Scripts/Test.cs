using System.Collections;
using Assets.MyAssets.Field.Scripts.Attacks.Imples;
using Assets.MyAssets.Field.Scripts.Players;
using UnityEngine;
using UniRx;

public class Test : MonoBehaviour
{
    [SerializeField]
    private PlayerCore _playerCore;

    [SerializeField]
    private PlayerGear _playerGear;

    void Start()
    {
        _playerCore.InitializePlayer();
        _playerCore.EquipGear(_playerGear);
        
        _playerCore.CurrentPlayerParameter.ObserveReplace()
            .Subscribe(x =>
            {
                Debug.Log($"{x.Key}が{x.OldValue}から{x.NewValue}に変わったよ!");
            });
    }
}
