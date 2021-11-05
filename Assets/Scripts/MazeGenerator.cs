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
     * 1 - 3 walls (blank at bottom)
     * 2 - 3 walls (blank at left)
     * 3 - 2 walls (blank at bottom and left)
     */
    int type;
    bool[] hidden;
    GameObject[] quads;
    GameObject[] mirrorQuads;//quads of the same position facing the other way

    static float sectorSize;
    static int mazeSize;

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
        mirrorQuads = new GameObject[quadAmount];
        float startX = ((mazeSize % 2 == 0) ? sectorSize / 2 : 0);
        for(int i = 0; i < quadAmount; i++)
        {
            hidden[i] = false;
            quads[i] = GameObject.Instantiate(quad, quad.gameObject.transform.position, quad.gameObject.transform.rotation);
            quads[i].gameObject.transform.localScale = new Vector3(sectorSize,
                quad.gameObject.transform.localScale.y, 1);
            quads[i].gameObject.transform.position = quads[i].gameObject.transform.position +
                new Vector3(startX + xOffset * sectorSize, 0, startX + yOffset * sectorSize);

            mirrorQuads[i] = GameObject.Instantiate(quad, quad.gameObject.transform.position, quad.gameObject.transform.rotation);
            mirrorQuads[i].gameObject.transform.localScale = new Vector3(sectorSize,
                quad.gameObject.transform.localScale.y, 1);
            //leave mirrorQuads positioning for the following
        }

        //position the walls relative to its sector point
        if(type == 0)
        {
            quads[0].gameObject.transform.position = quads[0].gameObject.transform.position +
                new Vector3(0, 0, sectorSize / 2);
            quads[1].gameObject.transform.Rotate(0, -90, 0);
            quads[1].gameObject.transform.position = quads[1].gameObject.transform.position +
                new Vector3(sectorSize / 2, 0, 0);
            quads[2].gameObject.transform.position = quads[2].gameObject.transform.position +
                new Vector3(0, 0, -sectorSize / 2);
            quads[3].gameObject.transform.Rotate(0, -90, 0);
            quads[3].gameObject.transform.position = quads[3].gameObject.transform.position +
                new Vector3(-sectorSize / 2, 0, 0);

            mirrorQuads[0].gameObject.transform.Rotate(0, 0, 180);
            mirrorQuads[1].gameObject.transform.Rotate(0, 90, 0);
            mirrorQuads[2].gameObject.transform.Rotate(0, 0, 180);
            mirrorQuads[3].gameObject.transform.Rotate(0, 90, 0);
        }
        else if(type == 1)
        {
            quads[0].gameObject.transform.position = quads[0].gameObject.transform.position +
                new Vector3(0, 0, sectorSize / 2);
            quads[1].gameObject.transform.Rotate(0, -90, 0);
            quads[1].gameObject.transform.position = quads[1].gameObject.transform.position +
                new Vector3(sectorSize / 2, 0, 0);
            quads[2].gameObject.transform.Rotate(0, -90, 0);
            quads[2].gameObject.transform.position = quads[2].gameObject.transform.position +
                new Vector3(-sectorSize / 2, 0, 0);

            mirrorQuads[0].gameObject.transform.Rotate(0, 0, 180);
            mirrorQuads[1].gameObject.transform.Rotate(0, 90, 0);
            mirrorQuads[2].gameObject.transform.Rotate(0, 90, 0);
        }
        else if(type == 2)
        {
            quads[0].gameObject.transform.position = quads[0].gameObject.transform.position +
                new Vector3(0, 0, sectorSize / 2);
            quads[1].gameObject.transform.Rotate(0, -90, 0);
            quads[1].gameObject.transform.position = quads[1].gameObject.transform.position +
                new Vector3(sectorSize / 2, 0, 0);
            quads[2].gameObject.transform.position = quads[2].gameObject.transform.position +
                new Vector3(0, 0, -sectorSize / 2);

            mirrorQuads[0].gameObject.transform.Rotate(0, 0, 180);
            mirrorQuads[1].gameObject.transform.Rotate(0, 90, 0);
            mirrorQuads[2].gameObject.transform.Rotate(0, 0, 180);
        }
        else
        {
            quads[0].gameObject.transform.position = quads[0].gameObject.transform.position +
                new Vector3(0, 0, sectorSize / 2);
            quads[1].gameObject.transform.Rotate(0, -90, 0);
            quads[1].gameObject.transform.position = quads[1].gameObject.transform.position +
                new Vector3(sectorSize / 2, 0, 0);

            mirrorQuads[0].gameObject.transform.Rotate(0, 0, 180);
            mirrorQuads[1].gameObject.transform.Rotate(0, 90, 0);
        }

        for (int i = 0; i < quadAmount; i++)
            mirrorQuads[i].gameObject.transform.position = quads[i].gameObject.transform.position;
    }

    /// <summary>
    /// Sets whether the specifie wall is hidden based on the sector type.
    /// </summary>
    /// <param name="index"></param>
    public void SetWallHidden(int index, bool isHidden)
    {
        string err = "Index is out of range for the respective sector type.";
        hidden[index] = isHidden;
        quads[index].SetActive(!isHidden);
        mirrorQuads[index].SetActive(!isHidden);

        switch (type)
        {
            case 0:
                if (index < 0 || index > 3)
                    throw new ArgumentException(err);
                break;
            case 1:
            case 2:
                if(index < 0 || index > 2)
                    throw new ArgumentException(err);
                break;
            case 3:
            default:
                if(index < 0 || index > 1)
                    throw new ArgumentException(err);
                break;
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

    public static void SetMazeSize(int mazeSize)
    {
        MazeSector.mazeSize = mazeSize;
    }
}

public class MazeGenerator : MonoBehaviour
{
    const int SIZE = 6;//the area of the grid (SIZE X SIZE)
    MazeSector[,] sectors = new MazeSector[SIZE, SIZE];
    GameObject plane, standardWall;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.Find("Plane");
        standardWall = GameObject.Find("Plane/StandardWall");
        MazeSector.SetSectorSize(10.0f * plane.gameObject.transform.localScale.x / (float)SIZE);
        MazeSector.SetMazeSize(SIZE);
        InitSectors();
        standardWall.SetActive(false);
        GeneratePath();
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

    void GeneratePath()
    {
        sectors[0, 0].SetWallHidden(3, true);
        sectors[SIZE - 1, SIZE - 1].SetWallHidden(1, true);
    }
}
