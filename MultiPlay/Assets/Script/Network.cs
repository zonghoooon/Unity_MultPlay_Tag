using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime; 

public class Network : MonoBehaviourPunCallbacks
{
    public GameObject Cube;
    public string gameVersion = "1.0";
    public Text connectState;


    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }
    private void FixedUpdate()
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
            connectState.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " Players";
        }
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        GameObject temp = PhotonNetwork.Instantiate("Boy", Cube.transform.position, Quaternion.identity);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        this.CreateRoom();
    }

    void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }

}