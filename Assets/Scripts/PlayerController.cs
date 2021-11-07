using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    //create private internal references
    private InputActions inputActions;
    private InputAction movement;
    public CharacterController controller;
    public float speed = 12f;

    Vector2 contInput;
    

    private void Awake()
    {
        inputActions = new InputActions();//create new InputActions
        
        
    }

    //called when script enabled
    private void OnEnable()
    {
        movement = inputActions.Player.Movement;//get r eference to movement action
        movement.Enable();
        
    }

    //called when script disabled
    private void OnDisable() 
    {
        movement.Disable();
    }

    //called every physics update
    private void FixedUpdate()
    {
        Vector2 v2 = movement.ReadValue<Vector2>();//extract 2d input data
        Vector3 v3 = new Vector3(v2.x, 0, v2.y);//convert to 3d space
        Vector3 move = transform.right * v3.x + transform.forward * v3.z;


        controller.Move(move * speed * Time.deltaTime);
        // transform.Translate(v3);
        //Debug.Log("Movement values " + v2);

        // if (transform.position.x < -35)
        // {
        //     transform.position = new Vector3(-34.5f, 0, 40);
        // }
        // if (transform.position.x > 35)
        // {
        //     transform.position = new Vector3(34.5f, 0, 40);
        // }
    }
}