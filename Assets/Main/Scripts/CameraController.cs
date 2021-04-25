using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    public Vector3 offset;
    private Camera cam;
    private Ray camRay;
    private Vector3 mousePoint;
    private Vector3 playerToMouse;
    // Start is called before the first frame update
    void Start()
    {
        this.cam = GetComponent<Camera>();
        this.mousePoint = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        this.camRay = this.cam.ScreenPointToRay(
            Input.mousePosition
        );

        this.mousePoint.x = (
            (this.player.transform.position.y - camRay.origin.y) / 
            camRay.direction.y) * 
            camRay.direction.x + camRay.origin.x
        ;
        this.mousePoint.z = (
            (this.player.transform.position.y - camRay.origin.y) /
            camRay.direction.y) *
            camRay.direction.z + camRay.origin.z
        ;

        this.mousePoint.y = this.player.transform.position.y;

        //Debug.DrawLine(this.camRay.origin, this.mousePoint);

        this.playerToMouse = this.mousePoint - 
            this.player.transform.position;
        this.playerToMouse /= 4;

        this.player.lookDirection = this.playerToMouse;

        this.transform.position = 
            (this.player.transform.position +
            this.playerToMouse) + this.offset;
        this.transform.rotation = Quaternion
            .LookRotation(-this.offset);
    }
}
