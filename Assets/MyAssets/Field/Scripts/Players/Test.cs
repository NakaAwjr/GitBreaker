using Assets.MyAssets.Field.Scripts.Players;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        Debug.Log(PlayerIdUtility.GetIDFromPlayerName("1P"));
    }
}
