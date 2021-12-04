using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Box collided: + " + Time.deltaTime);
    }
}