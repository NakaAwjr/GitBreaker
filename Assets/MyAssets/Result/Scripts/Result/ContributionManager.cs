using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContributionManager : MonoBehaviour
{
    [SerializeField] int contribution = 0;
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        SetContribution();
    }
    
    void SetContribution(){
        text.text = "Cntribution:" + contribution.ToString();
    }
}
