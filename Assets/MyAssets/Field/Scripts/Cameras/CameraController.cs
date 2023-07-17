using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.GameManagers;
using Photon.Pun;
using UnityEngine;

namespace Assets.MyAssets.Field.Cameras
{
    public class CameraController : MonoBehaviour
    {
        private GameObject[] _players;
        private GameObject _player;
        
        IEnumerator Start()
        {
            yield return new WaitForSeconds(1);
            _players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in _players)
            {
                if (player.GetComponent<PhotonView>().IsMine)
                {
                    _player = player;
                }
            }
            Debug.Log(_player.transform.position);
        }

        void LateUpdate()
        {
            if (_player == null || Camera.main == null) return;
            Camera.main.gameObject.transform.position = _player.transform.position + new Vector3(0f,0f,-10f);
        }
        
    }
}
