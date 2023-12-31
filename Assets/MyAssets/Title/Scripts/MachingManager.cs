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
    [SerializeField] List<GameObject> _youtextlist;
    [SerializeField] private TMP_Text _roomidtext;

    public string RoomID { get; set; } = "";
    public int PlayerCount { get; set; } = 1;
    public int PlayerNumber { get; set; } = 0;

    //マッチング画面が呼び出されたとき
    public void StartMaching()
    {
        //表示を初期化
        for (int i = 0; i < _youtextlist.Count; i++)
        {
            _youtextlist[i].SetActive(false);
        }

        Room myroom = PhotonNetwork.CurrentRoom;
        if (RoomID == "")
        {
            _roomidtext.text = "Room Not Found";
            return;
        }
        _roomidtext.text = "RoomID: "+RoomID;
        Debug.Log("RoomName:" + RoomID);
    }

    //プレイヤー数分だけプレイヤーを表示、出来ればyouの文字も表示
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
        //for (int i = 0; i < _youtextlist.Count; i++)
        //{
          //  if (i == PlayerNumber-1)
            //{
              //  _youtextlist[i].SetActive(true);
            //}
            //else
            //{
              //  _youtextlist[i].SetActive(false);
            //}
        //}
    }
}
