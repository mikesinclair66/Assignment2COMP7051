using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCollide : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    public AudioSource moveSound;
    public AudioSource wallHitSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (IsPlayerMoving(x, z) && !moveSound.isPlaying)
        {
            moveSound.Play();
        }

        if (!IsPlayerMoving(x, z))
        {
            moveSound.Stop();
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            killPlayer();
            return;
        }
        if (hit.gameObject.tag == "Wall")
        {
            if (!wallHitSound.isPlaying)
            {
                wallHitSound.Play();
            }
        }
    }

    public bool IsPlayerMoving(float x, float z)
    {
        return x != 0 || z != 0;
    }
    
    void killPlayer()
    {
        GameObject.Find("GameMaster").GetComponent<Reset>().resetGame();
    }
}