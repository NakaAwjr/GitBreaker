using System.Collections;
using System.Collections.Generic;
using Assets.MyAssets.Field.Scripts.Players;
using Photon.Pun;
using UniRx;
using UnityEngine;

namespace Assets.MyAssets.Field.Scripts.GameManagers
{
    public class PlayerProvider : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerPrefab;

        private ReactiveDictionary<PlayerId, PlayerCore> _players = new ReactiveDictionary<PlayerId, PlayerCore>();

        /// <summary>
        /// 現在のPlayer
        /// </summary>
        public IReadOnlyReactiveDictionary<PlayerId, PlayerCore> Players
        {
            get { return _players; }
        }

        public PlayerCore CreatePlayer(PlayerId id, Vector3 position, IGameStateProvider gameStateProvider)
        {
            var go = PhotonNetwork.Instantiate("Player", position + new Vector3(Random.Range(-2, 3), Random.Range(-2, 3),0f), Quaternion.identity);
            var core = go.GetComponent<PlayerCore>();
            core.InitializePlayer(id, gameStateProvider);
            _players.Add(id, core);
            return core;
        }
    }
}
