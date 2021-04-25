using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 lookDirection;
    private Vector3 input;
    private float speed;
    private Rigidbody rigBody;
    private Vector3 tmpEulerRot;
    // Start is called before the first frame update
    void Start()
    {
        this.input = Vector3.zero;
        this.speed = 5;
        this.rigBody = GetComponent<Rigidbody>();
        this.lookDirection = Vector3.zero;
        this.tmpEulerRot = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        this.input.Set(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
            );
        this.tmpEulerRot.y = Quaternion.LookRotation(
            this.lookDirection).eulerAngles.y;
        this.transform.rotation = Quaternion.Euler(this.tmpEulerRot);
    }
    void FixedUpdate() 
    { 
        if (this.input != Vector3.zero)
        {
            this.rigBody.velocity = 
                this.input * this.speed;
        }
    }
}
