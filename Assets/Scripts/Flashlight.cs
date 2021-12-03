using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    private InputActions inputActions;
    public GameObject light;
    public bool flashlightOn = true;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player.ToggleFlashlight.performed += context =>
        {
            toggleFlashlight();
        };
    }

    private void OnEnable()
    {
        inputActions.Player.ToggleFlashlight.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.ToggleFlashlight.Disable();
    }

    void toggleFlashlight()
    {
        if (flashlightOn == true)
        {
            flashlightOn = false;
            light.SetActive(false);
        }
        else
        {
            flashlightOn = true;
            light.SetActive(true);
        }
    }
}
