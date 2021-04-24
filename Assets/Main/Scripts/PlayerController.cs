using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 input;
    private float speed;
    private Rigidbody rigBody;
    // Start is called before the first frame update
    void Start()
    {
        this.input = Vector3.zero;
        this.speed = 5;
        this.rigBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.input.Set(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
            );
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
