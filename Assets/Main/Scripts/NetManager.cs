using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NetManager : MonoBehaviour
{
    public Text connectionState;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("Alpha 0.1");
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRoom("Room_1");
    }

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(
            "Player",
            new Vector3(0, 1, 0),
            Quaternion.identity,
            0
        );
    }

    void OnPhotonJoinRoomFailed()
    {
        Debug.Log("OnJoinedRoomFailed");
        PhotonNetwork.CreateRoom("Room_1");
    }

    void Update()
    {
        this.connectionState.text = 
            PhotonNetwork.connectionStateDetailed
                .ToString();
    }
}
