using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public string sceneName="";
    public void OnClick()
    {
        PhotonNetwork.Disconnect();
        SceneChange(sceneName);
    }
    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
    }
}
