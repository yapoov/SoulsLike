using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float spring;
    public float damper;
    public Rigidbody childRb;
    private Vector3 baseDist;
    // Start is called before the first frame update
    void Start()
    {
        baseDist = childRb.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaY = baseDist.y - (childRb.position - transform.position).y;
        childRb.velocity += Vector3.up * deltaY * spring * Time.deltaTime;
        childRb.velocity -= childRb.velocity * damper;
    }
}
