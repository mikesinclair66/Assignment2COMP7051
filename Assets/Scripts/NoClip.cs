using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClip : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public bool canCollide;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = false;
        canCollide = false;
    }

    // Update is called once per frame
    void Update()
    {
        controller.detectCollisions = canCollide;
    }

    void FixedUpdate() {
        if (Input.GetKeyDown("r"))
        {
            canCollide = !canCollide;
            Debug.Log("Toggled collision. Collision is now " + canCollide);
        }
        // else if (Input.GetKeyDown("t"))
        // {
        //     controller = GetComponent<CharacterController>();
        //     controller.detectCollisions = true;
        // }
    }
}
