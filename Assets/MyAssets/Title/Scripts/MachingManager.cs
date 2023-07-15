using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MachingManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _playerslist;
    [SerializeField] private TMP_Text _roomidtext;
    public string RoomID { get; set; } = "";
    public int PlayerCount { get; set; } = 1;

    public void StartMaching()
    {
        Room myroom = PhotonNetwork.CurrentRoom;
        if (RoomID == "")
        {
            _roomidtext.text = "Room Not Found";
            return;
        }
        _roomidtext.text = "RoomID: "+RoomID;
        Debug.Log("RoomName:" + RoomID);
    }

    public void SetPlayerCount()
    {
        for (int i = 0; i < _playerslist.Count; i++)
        {
            if (i < PlayerCount)
            {
                _playerslist[i].SetActive(true);
            }
            else
            {
                _playerslist[i].SetActive(false);
            }
        }
    }
}
