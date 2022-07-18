using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [System.Serializable]
    public struct InputState
    {
        public Vector3 direction;

        public bool isAiming;

        public System.Action fireEvent;

    }
    public InputState state;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        dir.z = Input.GetAxis("Vertical");
        dir.x = Input.GetAxis("Horizontal");

        state.direction = dir;


        state.isAiming = Input.GetMouseButton(1);

        if (Input.GetMouseButtonDown(0))
            state.fireEvent?.Invoke();
    }
}
