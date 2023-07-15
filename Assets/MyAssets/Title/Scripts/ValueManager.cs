using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    private TMPro.TMP_InputField _roomidinoutfield;

    public bool IsRandom { get; set; } = false;
    public bool IsVisible { get; set; } = true;
    public string SearchRoomID { get; set; } = "";

    private bool _israndom = false;
    private bool _isvisible = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetRandom(bool israndom) => _israndom = israndom;
    public void ClickEnter()
    {
        _roomidinoutfield = GameObject.Find("RoomIDInputField").GetComponent<TMPro.TMP_InputField>();
        IsRandom = _israndom;
        SearchRoomID = _roomidinoutfield.text;
        Debug.Log("IsRandom:"+IsRandom);
        Debug.Log("SearchRoomID:"+SearchRoomID);
    }

    public void SetIsVisible(bool isvisible) => _isvisible = isvisible;
    public void ClickCreate()
    {
        IsVisible = _isvisible;
        Debug.Log("IsVisible:"+IsVisible);
    }

}
