using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]int MaxMapSize=50;
    [SerializeField]int MaxRoom = 150;
    GameObject Room;
    [SerializeField] List<GameObject> RoomList;
    [SerializeField] GameObject BossRoom;
    [SerializeField] GameObject StartRoom;
    GameObject[,] MapGrid;
    int[] currentPosition = new int[2];
    int[] nextDirectionVec = new int[2];
    int   nextDirection = 0;
    int[] nextPosition = new int[2];
    int[] pastPosition = new int[2];
    int CntRoom = 0;

    void Start(){
        MapGrid = new GameObject[MaxMapSize,MaxMapSize];
        GenerateMap();
    }
    void GenerateMap()
    {
        SetCurrentPosition((int)(MapGrid.GetLength(0)/2),0);
        SelectRoom();
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
    }
    void CreateRoom(){
        Vector3 pos = new Vector3(currentPosition[0]*10,currentPosition[1]*10,0);
        var Roomobj = Instantiate(Room,pos,transform.rotation);
        MapGrid[currentPosition[0],currentPosition[1]] = Roomobj;
        CntRoom++;
    }
    void CreateRoot(){
        GameObject currentRoom = MapGrid[currentPosition[0],currentPosition[1]];
        GameObject pastRoom    = MapGrid[pastPosition[0]   ,pastPosition[1]];
        Destroy(pastRoom.transform.GetChild(2).transform.GetChild(nextDirection).gameObject);
        if(nextDirection%2==0){
            Destroy(currentRoom.transform.GetChild(2).transform.GetChild(nextDirection+1).gameObject);    
        }else{
            Destroy(currentRoom.transform.GetChild(2).transform.GetChild(nextDirection-1).gameObject);    
        }
    }
    bool CheckWall(){
        int tempNextPosX = currentPosition[0]+nextDirectionVec[0];
        int tempNextPosY = currentPosition[1]+nextDirectionVec[1];
        bool isWallX=(0<=tempNextPosX && tempNextPosX<MapGrid.GetLength(0));
        bool isWallY=(0<=tempNextPosY && tempNextPosY<MapGrid.GetLength(1));
        return isWallX && isWallY;
    }
    bool CheckRoot(){
        GameObject currentobj = MapGrid[currentPosition[0],currentPosition[1]];
        if(currentobj == null){
            return false;
        }
        return currentobj.transform.Find("root").gameObject.GetComponent<fillRoot>().getIsRoot(nextDirection);
    }
    bool CheckRoom(){
        int tempNextPosX = currentPosition[0];
        int tempNextPosY = currentPosition[1];
        if(MapGrid[tempNextPosX,tempNextPosY] == null){
            return false;
        }
        else{
            return true;
        }
    }
    bool CheckMaxRoom(){
        if(MaxRoom <= CntRoom){
            return true;
        } else {
            return false;
        }
    }
    void SetCurrentPosition(int x,int y){
        pastPosition[0] = currentPosition[0];
        pastPosition[1] = currentPosition[1];
        currentPosition[0] = x;
        currentPosition[1] = y;
    }
    void SetNextPosition(){
        nextPosition[0] = currentPosition[0]+nextDirectionVec[0];
        nextPosition[1] = currentPosition[1]+nextDirectionVec[1];
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
    }
    void SelectRoom()
    {
        if(CntRoom == 0)
        {
            Room = StartRoom;
        }
        else if(CntRoom == MaxRoom)
        {
            Room = BossRoom;
        }
        else
        {
            Room = RoomList[Random.Range(0,RoomList.Count)];
        }
    }
}
