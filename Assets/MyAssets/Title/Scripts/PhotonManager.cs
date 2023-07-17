using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEditor;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public ValueManager ValueManager;
    public MoveManager MoveManager;
    public MachingManager MachingManager;
    private bool _iscreate;

    //マスターサーバーへ接続
    public void StartConnect(bool iscreate)
    {
        PhotonNetwork.ConnectUsingSettings();
        _iscreate = iscreate;
        Debug.Log("iscreate"+_iscreate);
        
    }

    //部屋を作成、または部屋に入室
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        if (_iscreate)
        {
            Debug.Log("CreateRoom");
            PhotonNetwork.CreateRoom(null,
                new Photon.Realtime.RoomOptions { 
                    MaxPlayers = 4,
                    IsVisible = ValueManager.IsVisible
                });
        }
        else if (!_iscreate && ValueManager.IsRandom)
        {
            Debug.Log("JoinRandomRoom");
            PhotonNetwork.JoinRandomRoom();
        }
        else if (!_iscreate && ValueManager.SearchRoomID == "" && !ValueManager.IsRandom)
        {
            MoveManager.Error();
        }
        else if (!_iscreate && !ValueManager.IsRandom)
        {
            Debug.Log("JoinRoom");
            PhotonNetwork.JoinRoom(ValueManager.SearchRoomID);
        }
        else
        {
            MoveManager.Error();
            PhotonNetwork.Disconnect();
        }
    }
    //ランダム部屋がなかったとき(自動でオープンとする)
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed");
        PhotonNetwork.CreateRoom(null,
                       new Photon.Realtime.RoomOptions
                       {
                           MaxPlayers = 4,
                           IsVisible = true
                       });
    }

    //部屋に入ったとき
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        Room myroom = PhotonNetwork.CurrentRoom;
        MachingManager.RoomID = myroom.Name;
        SetPlayerInfo();
        MoveManager.EndConnect();
    }
    //エラー系
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnDisconnected");
        MoveManager.Error();
        PhotonNetwork.Disconnect();
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRoomFailed");
        MoveManager.Error();
        PhotonNetwork.Disconnect();
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnCreateRoomFailed");
        MoveManager.Error();
        PhotonNetwork.Disconnect();
    }

    //出入りするたびに自分の情報と人数を更新
    void SetPlayerInfo()
    {
        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
        Photon.Realtime.Player localplayer = PhotonNetwork.LocalPlayer;

        MachingManager.PlayerCount = players.Length;
        MachingManager.PlayerNumber = localplayer.ActorNumber;
        MachingManager.SetPlayerCount();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        SetPlayerInfo();
    }
    public override void OnPlayerLeftRoom(Player player)
    {
        SetPlayerInfo();
    }

}
