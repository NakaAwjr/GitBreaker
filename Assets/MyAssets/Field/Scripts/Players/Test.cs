using Assets.MyAssets.Field.Scripts.Players;
using Assets.MyAssets.Field.Scripts.States;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private CharacterStates hoge;
    void Start()
    {
        Debug.Log(hoge.Hp);
    }
}
