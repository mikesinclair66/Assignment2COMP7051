using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MazeSector
{
    /*
     * type indicates the walls of the sector, respectively starting from the top
     * and going clockwise.
     * 0 - 4 walls
     * 1 - 3 walls (blank at top)
     * 2 - 3 walls (blank at left)
     * 3 - 2 walls (blank at top and left)
     */
    int type;
    bool[] hidden;
    GameObject[] quads;

    static float sectorSize;

    public MazeSector(int type, GameObject quad,
        float xOffset, float yOffset)
    {
        if (type < 0 || type > 3)
            throw new ArgumentException("type is out of range.");

        this.type = type;
        int quadAmount;
        switch (type)
        {
            case 0:
                quadAmount = 4;
                break;
            case 1:
            case 2:
                quadAmount = 3;
                break;
            case 3:
            default:
                quadAmount = 2;
                break;
        }

        hidden = new bool[quadAmount];
        quads = new GameObject[quadAmount];
        for(int i = 0; i < quadAmount; i++)
        {
            hidden[i] = false;
            quads[i] = GameObject.Instantiate(quad, quad.gameObject.transform.position, quad.gameObject.transform.rotation);
            quads[i].gameObject.transform.localScale = new Vector3(sectorSize,
                quad.gameObject.transform.localScale.y, 1);
            quads[i].gameObject.transform.position = quads[i].gameObject.transform.position +
                new Vector3(sectorSize / 2 + xOffset * sectorSize, 0, sectorSize / 2 + yOffset * sectorSize);
        }
    }

    /// <summary>
    /// Sets the sector size or space between each parallel wall
    /// </summary>
    /// <param name="sectorSize"></param>
    public static void SetSectorSize(float sectorSize)
    {
        MazeSector.sectorSize = sectorSize;
        //Debug.Log("Sector size: " + sectorSize);
    }
}

public class MazeGenerator : MonoBehaviour
{
    const int SIZE = 8;
    MazeSector[,] sectors = new MazeSector[SIZE, SIZE];
    GameObject plane, standardWall;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
        standardWall = GameObject.Find("Plane/StandardWall");
        MazeSector.SetSectorSize(10.0f * plane.gameObject.transform.localScale.x / (float)SIZE);
        InitSectors();
        standardWall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitSectors()
    {
        for(int r = 0; r < SIZE; r++)
        {
            for(int c = 0; c < SIZE; c++)
            {
                int type;
                if (r > 0 && c > 0)
                    type = 3;
                else if (c > 0)
                    type = 2;
                else if (r > 0 && c == 0)
                    type = 1;
                else
                    type = 0;

                sectors[r, c] = new MazeSector(type, standardWall,
                    c - SIZE / 2, r - SIZE / 2);
            }
        }
    }
}
