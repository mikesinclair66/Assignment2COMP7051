using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLook : MonoBehaviour
{
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 8f;

    float controllerX, controllerY;

    public void ReceiveInput (Vector2 contInput)
    {
        controllerX = contInput.x * sensitivityX;
        controllerY = contInput.y * sensitivityY;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, controllerX * Time.deltaTime);
    }
}
