using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClip : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public bool canCollide;
    public GameObject[] walls;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        SetCollision(canCollide);
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCollision(bool canCollide)
    {
        foreach (GameObject wall in walls)
        {
            Physics.IgnoreCollision(wall.GetComponent<Collider>(), GetComponent<Collider>(), !canCollide);
        }
    }

    void FixedUpdate() {
        if (Input.GetKeyDown("r"))
        {
            canCollide = !canCollide;
            Debug.Log("Toggled collision. Collision is now " + canCollide);
            SetCollision(canCollide);
        }
        // else if (Input.GetKeyDown("t"))
        // {
        //     controller = GetComponent<CharacterController>();
        //     controller.detectCollisions = true;
        // }
    }
}
