using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public int force;
    private Vector3 forward;
    private bool requestApplyForce;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (requestApplyForce)
        {
            rb.AddForce(forward * force);
            requestApplyForce = false;
        }
    }

    public void ApplyForce(Vector3 direction)
    {
        forward = direction;
        requestApplyForce = true;
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Enemy") {
            col.gameObject.GetComponent<DudeEnemy>().TakeDamage();
        }
    }
}
