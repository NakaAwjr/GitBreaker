using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLevelManger : MonoBehaviour
{
    [SerializeField] int FinishLevel = 0;
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        SetFinishLevel();
    }
    
    void SetFinishLevel()
    {
        text.text = "Level:" + FinishLevel.ToString();
    }
}
