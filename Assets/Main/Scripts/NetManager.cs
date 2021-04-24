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
        PhotonNetwork.autoJoinLobby = true;
        PhotonNetwork.ConnectUsingSettings("Alpha 0.1");
    }

    void Upate()
    {
        this.connectionState.text = 
            PhotonNetwork.connectionStateDetailed
                .ToString();
    }
}
