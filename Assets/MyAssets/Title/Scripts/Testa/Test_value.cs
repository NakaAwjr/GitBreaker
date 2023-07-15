using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_value : MonoBehaviour
{
    public ValueManager valueManager;
    
    public void ClickEnter()
    {
        Debug.Log("isRandom: " + valueManager.IsRandom);
        Debug.Log("SearchRoomID: " + valueManager.SearchRoomID);
    }
}
