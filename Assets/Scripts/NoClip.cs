using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClip : MonoBehaviour
{
    public static NoClip instance;
    // Start is called before the first frame update
    public CharacterController controller;
    public bool canCollide;
    public GameObject[] walls;
    public GameObject[] portals;
    void Start()
    {
        instance = this;
        controller = GetComponent<CharacterController>();
        SetCollision(canCollide);
        walls = GameObject.FindGameObjectsWithTag("Wall");
        portals = GameObject.FindGameObjectsWithTag("Portal");
        foreach(GameObject p in portals)
        {
            Physics.IgnoreCollision(p.GetComponent<Collider>(), GetComponent<Collider>(), false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") || Input.GetKeyDown("joystick button 0"))
        {
            canCollide = !canCollide;
            Debug.Log("Toggled collision. Collision is now " + canCollide);
            SetCollision(canCollide);
        }
    }

    public void SetCollision(bool canCollide)
    {
        foreach (GameObject wall in walls)
        {
            Physics.IgnoreCollision(wall.GetComponent<Collider>(), GetComponent<Collider>(), !canCollide);
        }
    }
}
