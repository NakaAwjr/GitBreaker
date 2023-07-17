using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.GameManagers;
using TMPro;
using UniRx;
using UnityEngine;

public class LimitSeconds : MonoBehaviour
{
    [SerializeField]
    private TimeManager _timeManager;

    [SerializeField] 
    private TMP_Text _limitText;

    void Start()
    {
        _limitText.text = "";
        _timeManager.SearchSecond
            .Subscribe(x =>
            {
                _limitText.text = $"{x%60}:{x/60}";
                if (x <= 0)
                {
                    _limitText.text = "Time Over";
                } 
            });
    }
}
