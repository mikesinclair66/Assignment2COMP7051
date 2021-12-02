using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DudeEnemy : MonoBehaviour
{
    public GameObject Player;
    public float Distance;

    public bool isAngered;

    public NavMeshAgent _agent;

    public int maxHealth;
    public int health;

    private void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);
        Animator anim = GetComponent<Animator>();

        if (Distance <= 50)
        {
            isAngered = true;
        }
        if (Distance > 50f)
        {
            isAngered = false;
        }

        if (isAngered)
        {
            anim.enabled = true;
            anim.Play("Dude Walk");
            _agent.isStopped = false;
            _agent.SetDestination(Player.transform.position);
        }
        if (!isAngered)
        {
            anim.enabled = false;
            anim.StopPlayback();
            _agent.isStopped = true;
        }
    }

    private void FixedUpdate()
    {
        if (Distance < 3f)
        {
            killPlayer();
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void killPlayer()
    {
        GameObject.Find("GameMaster").GetComponent<Reset>().resetGame();
    }
}
