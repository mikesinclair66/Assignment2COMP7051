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
    private InputAction rotate;
    public CharacterController controller;
    public float speed = 12f;
    public GameObject camera;

    private float xClamp = 85f;
    private float xRotation = 0f;

    Vector2 contInput;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        inputActions = new InputActions();//create new InputActions
        
        
    }

    //called when script enabled
    private void OnEnable()
    {
        movement = inputActions.Player.Movement;//get r eference to movement action
        movement.Enable();
        rotate = inputActions.Player.Rotate;
        rotate.Enable();
        
    }

    //called when script disabled
    private void OnDisable() 
    {
        movement.Disable();
        rotate.Disable();
    }

    //called every physics update
    private void FixedUpdate()
    {
        Vector2 v2 = movement.ReadValue<Vector2>();//extract 2d input data
        Vector3 v3 = new Vector3(v2.x, 0, v2.y);//convert to 3d space

        Vector2 rtv2 = rotate.ReadValue<Vector2>();
        Vector3 rtv3 = new Vector3(rtv2.x, -rtv2.y, 0);

        Vector3 move = transform.right * v3.x + transform.forward * v3.z;
        controller.Move(move * speed * Time.deltaTime);

        Debug.Log(rtv3);
        //transform.localRotation = Quaternion.Euler(rtv3.x, rtv3.y,0f);
        camera.transform.Rotate(rtv3.y * Time.deltaTime, rtv3.x * Time.deltaTime, 0, Space.World );


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