using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MapGeneratorCopy : MonoBehaviour
{
    GameObject[,] MapGrid = new GameObject[50,50];
    int[] currentPosition = new int[2];
    int[] nextDirectionVec = new int[2];
    int   nextDirection = 0;
    int[] nextPosition = new int[2];
    int[] pastPosition = new int[2];
    int CntRoom = 0;
    [SerializeField]
    int MaxRoom = 150;
    //[SerializeField] GameObject Room;
    GameObject Room;
    [SerializeField] List<GameObject> RoomList;
    [SerializeField] GameObject BossRoom;
    [SerializeField] GameObject StartRoom;
    GameObject[] _players;

    void Start()
    {
        SetCurrentPosition((int)(MapGrid.GetLength(0)/2),0);
        CreateRoom();
        do{
            do{
                SelectRoot();
            }while(!CheckWall());
            SetCurrentPosition(currentPosition[0]+nextDirectionVec[0],currentPosition[1]+nextDirectionVec[1]);
            if(!CheckRoom())
            {
                CreateRoom();
            }
            if(!CheckRoot())
            {
                CreateRoot();
            }
        }while(!CheckMaxRoom());
        Show();
    }

    void SelectRoot(){
        
        nextDirection = Random.Range(0,4);
        switch (nextDirection){
            case 0:
                nextDirectionVec[0] = 1;
                nextDirectionVec[1] = 0;
                break;
            case 1:
                nextDirectionVec[0] = -1;
                nextDirectionVec[1] = 0;
                break;
            case 2:
                nextDirectionVec[0] = 0;
                nextDirectionVec[1] = -1;
                break;
            case 3:
                nextDirectionVec[0] = 0;
                nextDirectionVec[1] = 1;
                break;
        }
        // Debug.Log("[Debug] SelectRoot "+direction);
    }
    void CreateRoom(){
        SelectRoom();
        Vector3 pos = new Vector3(currentPosition[0]*10,currentPosition[1]*10,0);

        if (PhotonNetwork.IsMasterClient)
        {
            var Roomobj = PhotonNetwork.InstantiateRoomObject(Room.name,pos,transform.rotation);
        
            MapGrid[currentPosition[0],currentPosition[1]] = Roomobj;
        }

        CntRoom++;
        // Debug.Log("[Debug] CreateRoom "+currentPosition[0]+" "+currentPosition[1]);
    }
    void CreateRoot(){
        GameObject currentRoom = MapGrid[currentPosition[0],currentPosition[1]];
        GameObject pastRoom    = MapGrid[pastPosition[0]   ,pastPosition[1]];
        Destroy(pastRoom.transform.GetChild(2).transform.GetChild(nextDirection).gameObject);
        if(nextDirection%2==0){
            Destroy(currentRoom.transform.GetChild(2).transform.GetChild(nextDirection+1).gameObject);   
        }else
        {
            Destroy(currentRoom.transform.GetChild(2).transform.GetChild(nextDirection - 1).gameObject);
        }
        
    }
    bool CheckWall(){
        // Debug.Log("[Debug]CheckWall");
        int tempNextPosX = currentPosition[0]+nextDirectionVec[0];
        int tempNextPosY = currentPosition[1]+nextDirectionVec[1];
        // Debug.Log("[Debug]CheckWall X:"+tempNextPosX+" Y:"+tempNextPosY);
        bool isWallX=(0<=tempNextPosX && tempNextPosX<MapGrid.GetLength(0));
        bool isWallY=(0<=tempNextPosY && tempNextPosY<MapGrid.GetLength(1));
        // Debug.Log("[Debug]CheckWall :"+(isWallX&&isWallY));
        return isWallX && isWallY;
    }
    bool CheckRoot(){
        // Debug.Log("[Debug] CheckRoot");
        GameObject currentobj = MapGrid[currentPosition[0],currentPosition[1]];
        if(currentobj == null){
            // Debug.Log("currentObj == null");
            // Debug.Log("CheckRoot CPX:"+currentPosition[0]+" CPY:"+currentPosition[1]);
            return false;
        }
        // Debug.Log("[Debug] CheckRoot" + currentobj.transform.Find("root").gameObject.GetComponent<fillRoot>().getIsRoot(nextDirection));
        return currentobj.transform.Find("root").gameObject.GetComponent<fillRoot>().getIsRoot(nextDirection);
    }
    bool CheckRoom(){
        // Debug.Log("[Debug] CheckRoom");
        int tempNextPosX = currentPosition[0];
        int tempNextPosY = currentPosition[1];
        // Debug.Log("[Debug] CheckRoom XY " + (currentPosition[0]+nextDirectionVec[0]) + " " + (currentPosition[1]+nextDirectionVec[1]));
        if(MapGrid[tempNextPosX,tempNextPosY] == null){
            return false;
        }
        else{
           return true;
        }
        
    }
    bool CheckMaxRoom(){
        
        if(MaxRoom <= CntRoom){
            // Debug.Log("[Debug] CheckMaxRoom true");    
            return true;
        } else {
            // Debug.Log("[Debug] CheckMaxRoom false");
            return false;
        }
    }
    /* bool CheckFillRoot(){

    }*/
    void SetCurrentPosition(int x,int y){
        pastPosition[0] = currentPosition[0];
        pastPosition[1] = currentPosition[1];
        currentPosition[0] = x;
        currentPosition[1] = y;
        // Debug.Log("[Debug] SetCurrentPosition" + currentPosition[0] + " " + currentPosition[1]);
    }
    void SetNextPosition(){
        // Debug.Log("[Debug] SetNextPosition");
        nextPosition[0] = currentPosition[0]+nextDirectionVec[0];
        nextPosition[1] = currentPosition[1]+nextDirectionVec[1];
        // Debug.Log("[Debug] SetCurrentPosition" + currentPosition[0]+nextDirectionVec[0] + " " + currentPosition[1]+nextDirectionVec[1]);
    }
    void Show(){
        string str="";
        for (int i = 0; i<MapGrid.GetLength(0); i++)
        {
            for(int j = 0; j < MapGrid.GetLength(1); j++)
            {
                if(MapGrid[j,i] == null){
                    str= str+"0";
                }else{
                    str = str+"1";
                }
            }
            str = str + "\n";
        }
        // Debug.Log(str);
    }

    void SelectRoom()
    {
        Room = RoomList[Random.Range(0,RoomList.Count)];
        if(CntRoom == MaxRoom - 1)
        {
            Room = BossRoom;
        }
        if(CntRoom == 0)
        {
            Room = StartRoom;
        }
    }
}
