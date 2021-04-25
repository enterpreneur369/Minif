using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonView pv = GetComponent<PhotonView>();
        if (pv.isMine)
        {
            GetComponent<PlayerController>().enabled = 
                true;
            GetComponent<Rigidbody>().isKinematic =
                false;
            GameObject camera = GameObject
                .FindGameObjectWithTag("MainCamera");
            if (camera != null)
            {
                CameraController cc =
                    camera
                    .GetComponent<CameraController>();
                cc.enabled = true;
                cc.player = 
                    GetComponent<PlayerController>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
