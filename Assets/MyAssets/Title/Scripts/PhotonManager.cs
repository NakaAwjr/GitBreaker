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
        else if (!_iscreate && !ValueManager.IsRandom)
        {
            Debug.Log("JoinRoom");
            PhotonNetwork.JoinRoom(ValueManager.SearchRoomID);
        }
        else
        {
            Debug.Log("Error");
        }
    }

    //部屋に入ったとき
    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        Room myroom = PhotonNetwork.CurrentRoom;
        Photon.Realtime.Player player = PhotonNetwork.LocalPlayer;
        Debug.Log("RoomName:" + myroom.Name);
        Debug.Log("PlayerName:" + player.ActorNumber);

        MachingManager.RoomID = myroom.Name;

        MoveManager.EndConnect();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRoomFailed");
    }

    //ランダム部屋がなかったとき
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

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
        foreach (Photon.Realtime.Player p in players)
        {
            Debug.Log("PlayerName:" + p.ActorNumber);
        }
        Debug.Log(players.Length);
        MachingManager.PlayerCount = players.Length;
        MachingManager.SetPlayerCount();
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
        MachingManager.PlayerCount = players.Length;
        MachingManager.SetPlayerCount();
    }

}
