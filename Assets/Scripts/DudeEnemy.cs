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
}
