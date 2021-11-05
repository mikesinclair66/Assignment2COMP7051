using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MazeSector
{
    /*
     * 0 - 4 walls
     * 1 - 3 walls (blank at top)
     * 2 - 3 walls (blank at left)
     * 3 - 2 walls (blank at top and left)
     */
}

public class MazeGenerator : MonoBehaviour
{
    const int SIZE = 8;
    MazeSector[,] sectors = new MazeSector[SIZE, SIZE];
    GameObject standardWall;

    // Start is called before the first frame update
    void Start()
    {
        standardWall = GameObject.Find("Plane/StandardWall");
        InitSectors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitSectors()
    {

    }
}
