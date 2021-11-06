using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClip : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    void Start()
    {

        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("R Pressed");
            gameObject.GetComponent<CharacterController>().enabled = false;                  controller.detectCollisions = false;
        }
        else if (Input.GetKeyDown("t"))
        {
            controller = GetComponent<CharacterController>();
            controller.detectCollisions = true;
        }
    }
}
