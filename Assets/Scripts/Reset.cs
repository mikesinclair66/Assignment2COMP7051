using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject player, enemy;

    private Quaternion playerRotation, enemyRotation;

    public Vector3 playerPosition, enemyPosition;

    //private NoClip _noClip;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.transform.position;
        playerRotation = player.transform.rotation;
        enemyPosition = enemy.transform.position;
        enemyRotation = enemy.transform.rotation;

        Debug.Log("Start Pos: " + playerPosition);
        Debug.Log("Start Rot: " + playerRotation);
        //_noClip = NoClip.instance;
    }

    void Update()
    {
        if (Input.GetKeyDown("home") || Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("Reset Pos: " + playerPosition);
            Debug.Log("Reset Rot: " + playerRotation);

            resetGame();
            //_noClip.SetCollision(true);
        }
    }

    public void resetGame()
    {
        player.transform.position = playerPosition;
        player.transform.rotation = playerRotation;
        enemy.transform.position = enemyPosition;
        enemy.transform.rotation = enemyRotation;
        enemy.GetComponent<DudeEnemy>().health = enemy.GetComponent<DudeEnemy>().maxHealth;
    }
}
