using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public PlayerInput playerInput;

    public Rigidbody rb;

    public Rigidbody childRb;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = playerInput.state.direction; ;
        if (dir.magnitude > 1)
            dir = dir.normalized;

        var vel = rb.velocity;

        float vertical = vel.y;
        vel = Vector3.ProjectOnPlane(Camera.main.transform.TransformDirection(dir) * moveSpeed, Vector3.up);
        vel.y = vertical;
        // rb.rotation = Quaternion.LookRotation( Camera.main.transform.TransformDirection(dir));
        rb.velocity = vel;

        if (dir.magnitude > 0.1f)
        {
            childRb.rotation = Quaternion.Slerp(childRb.rotation, Quaternion.LookRotation(rb.velocity), Time.deltaTime * 5);
        }

    }
}
