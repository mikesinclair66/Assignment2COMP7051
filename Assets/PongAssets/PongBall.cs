using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    public Vector3 initialImpulse;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(initialImpulse, ForceMode.Impulse);
    }
}
