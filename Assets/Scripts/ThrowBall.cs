using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowBall : MonoBehaviour
{
    private InputActions inputActions;

    public float throwCooldown;
    private float currentCountdown;

    public GameObject ball;
    public Transform cameraTransform;
    public Transform throwPoint;
    private GameObject thrownBall;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player.ThrowBall.performed += context =>
        {
            Throw();
        };
    }
    private void OnEnable()
    {
        inputActions.Player.ThrowBall.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.ThrowBall.Disable();
    }

    private void Update()
    {
        if (OnCooldown())
        {
            currentCountdown -= Time.deltaTime;
        }
    }

    bool OnCooldown()
    {
        return currentCountdown > 0;
    }

    void Throw()
    {
        if (OnCooldown())
        {
            return;
        }
        
        thrownBall = Instantiate(ball, throwPoint.position, Quaternion.identity);
        thrownBall.GetComponent<Ball>().ApplyForce(transform.forward + cameraTransform.forward);
        currentCountdown = throwCooldown;
        Destroy(thrownBall, throwCooldown);
    }
}