using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _clearText;
    [SerializeField]
    private TMP_Text _isAlivePlayerText;
    [SerializeField]
    private TMP_Text _killCountText;
    
    public void SetArguments(bool isAliveBoss,bool isAlivePlayer, int killCount)
    {
        if (isAliveBoss)
        {
            _clearText.text = "Game Over...";
        }
        else
        {
            _clearText.text = "Game Clear!!";
        }
        
        if (_isAlivePlayerText)
        {
            _isAlivePlayerText.text = "Player Alive";
        }
        else
        {
            _isAlivePlayerText.text = "Player Die...";
        }

        _killCountText.text = $"You break {killCount} MG";
    }
}
