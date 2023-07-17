using Assets.MyAssets.Field.Scripts.Players;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;
using UniRx;


public class UIStatusValues : MonoBehaviour
{
    PlayerCore _playerCore;

    private GameObject[] _players;

    private List<int> _status;

    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private TMP_Text _mpText;
    [SerializeField] private TMP_Text _statusText;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Slider _mpSlider;

    [SerializeField] private TMP_Text _weaponText;
    [SerializeField] private TMP_Text _headText;
    [SerializeField] private TMP_Text _bodyText;
    [SerializeField] private TMP_Text _bottomText;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(5.5f);
        _players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in _players)
        {
            if (player.GetComponent<PhotonView>().IsMine)
            {
                _playerCore = player.GetComponent<PlayerCore>();
            }
        }
        
        _playerCore.CurrentPlayerParameter.ObserveReplace().Subscribe(x =>
        {
            switch(x.Key)
            { 
                case "Hp":
                    _hpText.text = "HP(" + x.NewValue + "/" + 10 + ")";
                    _hpSlider.value = x.NewValue;
                    break;
                case "Mp":
                    _mpText.text = "MP(" + x.NewValue + "/" + 10 + ")";
                    _mpSlider.value = x.NewValue;
                    break;
                case "Power":
                    _status[0] = x.NewValue;
                    break;
                case "Defence":
                    _status[1] = x.NewValue;
                    break;
                case "MagicPower":
                    _status[2] = x.NewValue;
                    break;
                case "MagicDefence":
                    _status[3] = x.NewValue;
                    
                    break;
                default:
                    break;
            }
            _statusText.text = "Power:" + _status[0] + "\n" +
                               "Defence:" + _status[1] + "\n" +
                               "MagicPower:" + _status[2] + "\n" +
                               "MagicDefence:" + _status[3];
        });
    }
}
