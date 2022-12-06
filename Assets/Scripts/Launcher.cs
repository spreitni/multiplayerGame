using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{

    public PhotonView playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("connecting to master");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        PhotonNetwork.JoinRandomOrCreateRoom();

    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room ");
        PhotonNetwork.Instantiate(playerPrefab.name,Vector3.zero,Quaternion.identity);
    }

}
