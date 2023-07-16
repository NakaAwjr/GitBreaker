using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillRootCopy : MonoBehaviour
{
    bool[] isRoot = new bool[4];
    void Start(){
        for (int i = 0; i<4; i++)
        {
            isRoot[i] = false;
        }
    }

    public bool getIsRoot(int direction){
        return isRoot[direction];
    }
}
