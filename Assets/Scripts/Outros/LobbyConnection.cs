//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Photon.Pun;
//using UnityEngine.SceneManagement;
///// <summary>
///// Script usado para conectar o projeto ao Photon
///// </summary>
//public class LobbyConnection : MonoBehaviourPunCallbacks
//{
//    private void Start()
//    {
//        PhotonNetwork.ConnectUsingSettings();
//    }

//    public override void OnConnectedToMaster()
//    {
//        PhotonNetwork.JoinLobby();
//    }

//    public override void OnJoinedLobby()
//    {
//         SceneManager.LoadScene("Lobby");
//    }

//}
