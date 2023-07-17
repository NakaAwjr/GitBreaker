using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.GameManagers;
using TMPro;
using UnityEngine;
using UniRx;

public class ReadyCountUI : MonoBehaviour
{
    [SerializeField]
    private TimeManager _timeManager;

    [SerializeField] 
    private TMP_Text _readyText;

    void Start()
    {
        _readyText.text = "";
        _timeManager.ReadySecond
            .Subscribe(x =>
            {
                _readyText.text = $"{x}";
                if (x > 3)
                {
                    _readyText.text = "Are You Ready?";
                }
                if (x <= 0)
                {
                    _readyText.text = "Start";
                    Destroy(gameObject);
                }
            });
    }
}
