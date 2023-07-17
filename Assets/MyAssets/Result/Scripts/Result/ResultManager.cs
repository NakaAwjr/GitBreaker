using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    [SerializeField] bool result = false;
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        setResult();
    }
    void setResult()
    {
        if (result)
        {
            text.text = "Victory";
        }
        else
        {
            text.text = "Defeat";
        }
    }
}
