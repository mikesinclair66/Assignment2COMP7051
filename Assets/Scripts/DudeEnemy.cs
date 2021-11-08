using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DudeEnemy : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent _agent;
    public GameObject plane;
    GameObject enemy;
    MazeGenerator mazeGenerator;
    Vector3 startPos;
    int SIZE;
    int prevX, prevY;
    int x, y;
    float distX, distY;
    float planeScale;
    int direction = 0;
    const float SPEED = 2.25f;
    bool paused = true;

    void Start()
    {
        enemy = GameObject.Find("Enemy");
        _agent.isStopped = false;
        planeScale = plane.transform.localScale.x;
        mazeGenerator = plane.GetComponent<MazeGenerator>();
        startPos = mazeGenerator.GetStartLocation();
        enemy.transform.position = startPos;
        SIZE = mazeGenerator.GetSize();
        x = SIZE - 1;
        y = x;
        prevX = x;
        prevY = y;
        distX = 0;
        distY = 0;
    }

    public void Init()
    {
        ChangeDirection(3);
        if (!mazeGenerator.IsSectorHidden(y, x - 1, 1))
            ChangeDirection(2);
        Animator anim = GetComponent<Animator>();
        anim.enabled = true;
        anim.Play("Dude Walk");
        paused = false;
    }

    void Update()
    {
        if (!paused)
        {
            switch (direction)
            {
                case 0:
                    distY += SPEED * Time.deltaTime;
                    break;
                case 1:
                    distX += SPEED * Time.deltaTime;
                    break;
                case 2:
                    distY -= SPEED * Time.deltaTime;
                    break;
                case 3:
                default:
                    distX -= SPEED * Time.deltaTime;
                    break;
            }
            enemy.transform.position = startPos
                + new Vector3(distX, 0, distY);

            for (int d = 0; d < SIZE - 1; d++)
            {
                if ((float)d * 30.0f / (float)SIZE <= Math.Abs(distX)
                    && (float)(d + 1) * 30.0f / (float)SIZE > Math.Abs(distX))
                {
                    x = SIZE - d - 1;
                }
            }

            for (int d = 0; d < SIZE - 1; d++)
            {
                if ((float)d * 30.0f / (float)SIZE <= Math.Abs(distY)
                    && (float)(d + 1) * 30.0f / (float)SIZE > Math.Abs(distY))
                {
                    y = SIZE - d - 1;
                }
            }

            if ((x != prevX && distX < -(SIZE - x - 1) * 30.0f / (float)SIZE/* - 15.0f / (float)SIZE*/)
                || (y != prevY && distY < -(SIZE - y - 1) * 30.0f / (float)SIZE/* - 15.0f / (float)SIZE*/))
            {
                prevX = x;
                prevY = y;
                FindRandomDirection();
            }
        }
    }

    void FindRandomDirection()
    {
        bool[] valid = { false, false, false, false };

        System.Random ran = new System.Random();
        //Debug.Log("Valid: {" + valid[0] + ", " + valid[1] + ", " + valid[2] + ", " + valid[3]);
        Debug.Log("Turn: X: " + x + ", Y: " + y);
        int validTurn = -1;
        paused = true;
        while(validTurn == -1)
        {
            validTurn = ran.Next(0, 4);

            if (y < SIZE)
            {
                valid[0] = mazeGenerator.IsSectorHidden(y, x, 0);
            }
            if (y - 1 >= 0)
            {
                valid[2] = mazeGenerator.IsSectorHidden(y - 1, x, 0);
            }

            if (x < SIZE)
            {
                valid[1] = mazeGenerator.IsSectorHidden(y, x, 1);
            }
            if (x - 1 >= 0)
            {
                valid[3] = mazeGenerator.IsSectorHidden(y, x - 1, 1);
            }

            if (!valid[validTurn]
                /*|| (validTurn == 0 && direction == 2 && valid[2])
                || (validTurn == 1 && direction == 3 && valid[3])
                || (validTurn == 2 && direction == 0 && valid[0])
                || (validTurn == 3 && direction == 1 && valid[1])*/)
                validTurn = -1;
        }

        ChangeDirection(validTurn);
        paused = false;
    }

    void ChangeDirection(int dir)
    {
        direction = dir;

        switch (dir)
        {
            case 0:
                enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 1:
                enemy.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case 2:
                enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 3:
            default:
                enemy.transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
        }
    }
}
