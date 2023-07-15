using System.Collections;
using Assets.MyAssets.Field.Scripts.Players;
using Assets.MyAssets.Field.Scripts.States;
using UnityEngine;
using UniRx;

public class Test : MonoBehaviour
{
    [SerializeField]
    private PlayerCore hoge;

    [SerializeField] 
    private PlayerGear _playerGear;
    
    IEnumerator Start()
    {
        hoge.CurrentPlayerParameter.ObserveReplace().Subscribe(x =>
        {
            Debug.Log($"{x.Key}が{x.OldValue}から{x.NewValue}になりました");
        });
        yield return new WaitForSeconds(5);
        hoge.EquipGear(_playerGear);
    }
}
