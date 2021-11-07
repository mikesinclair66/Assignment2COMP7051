using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    InputActions controls;
    Vector2 rotate;

    void Awake()
    {
        controls = new InputActions();

        controls.Player.Camera.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        controls.Player.Camera.canceled += ctx => rotate = Vector2.zero;
    }

    void Update()
    {
        Vector2 r = new Vector2(-rotate.y, -rotate.x) * 100f * Time.deltaTime;
        transform.Rotate(r, Space.World);
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
    }
}
