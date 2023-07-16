using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public void SetArguments(bool isAliveBoss,bool isAlivePlayer)
    {
        Debug.Log($"Bossは{isAliveBoss}、プレイヤーは{isAlivePlayer}");
    }
}
