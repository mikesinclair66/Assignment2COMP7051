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
    bool visited = false;

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

    public bool IsWallHidden(int index)
    {
        switch (type)
        {
            case 0:
                return hidden[index];
                break;
            case 1:
                if (index <= 1)
                    return hidden[index];
                else if (index == 2)
                    return true;
                else if (index == 3)
                    return hidden[2];
                break;
            case 2:
                if (index == 3)
                    return true;
                else
                    return hidden[index];
                break;
            case 3:
            default:
                if (index <= 1)
                    return hidden[index];
                else
                    return true;
        }

        return true;
    }

    public void AssignWallMaterial(int index, Material material)
    {
        string err = "Index is out of range for the respective sector type.";
        quads[index].GetComponent<Renderer>().material = material;
        mirrorQuads[index].GetComponent<Renderer>().material = material;

        switch (type)
        {
            case 0:
                if (index < 0 || index > 3)
                    throw new ArgumentException(err);
                break;
            case 1:
            case 2:
                if (index < 0 || index > 2)
                    throw new ArgumentException(err);
                break;
            case 3:
            default:
                if (index < 0 || index > 1)
                    throw new ArgumentException(err);
                break;
        }
    }

    public void SetVisited(bool visited)
    {
        this.visited = visited;
    }

    public bool IsVisited()
    {
        return visited;
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
    //TODO refactor backtrack code
    const int SIZE = 6;//the area of the grid (SIZE X SIZE)
    MazeSector[,] sectors = new MazeSector[SIZE, SIZE];
    GameObject plane, standardWall;

    public Material northWall, eastWall, southWall, westWall;

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
        GameObject.Find("Enemy").GetComponent<DudeEnemy>().Init();
        /*for(int r = 0; r < SIZE; r++)
        {
            for(int c = 0; c < SIZE; c++)
            {
                Debug.Log("R: " + r + ", C: " + c + ", valid: {" + IsSectorHidden(r, c, 0) + IsSectorHidden(r, c, 1)
                    + IsSectorHidden(r, c, 2) + IsSectorHidden(r, c, 3));
            }
        }*/
        //sectors[0, 0].SetWallHidden(3, true);
        //sectors[SIZE - 1, SIZE - 1].SetWallHidden(1, true);
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

        //assign materials
        int row = SIZE / 2, offset = row - ((SIZE % 2 == 0) ? 1 : 0);
        //north
        while(row < SIZE)
        {
            for(int c = offset; c < SIZE - offset; c++)
            {
                sectors[row, c].AssignWallMaterial(0, northWall);
                sectors[c, row].AssignWallMaterial(1, eastWall);
                if (c < SIZE - offset - 1)
                {
                    sectors[row, c].AssignWallMaterial(1, northWall);
                    sectors[c, row].AssignWallMaterial(0, eastWall);
                }
            }
            row++;
            offset--;
        }

        //south
        row = SIZE / 2 - 1;
        offset = row;
        while(row >= 0)
        {
            for(int c = offset; c < SIZE - offset; c++)
            {
                if (c < SIZE - offset - 1)
                {
                    sectors[row, c].AssignWallMaterial(1, southWall);
                    if(c > offset)
                        sectors[row, c].AssignWallMaterial(0, southWall);
                }
            }
            row--;
            offset--;
        }
        for (int c = 0; c < SIZE; c++)
        {
            sectors[0, c].AssignWallMaterial(2, southWall);
            sectors[c, 0].AssignWallMaterial(3 - ((c > 0) ? 1 : 0), westWall);
        }

        //west
        row = SIZE / 2 - 1;
        offset = row;
        while(row >= 0)
        {
            for(int c = offset; c < SIZE - offset; c++)
            {
                if(c < SIZE - offset - 1)
                {
                    sectors[c, row].AssignWallMaterial(0, westWall);
                    if (row < SIZE / 2 - ((SIZE % 2 == 0) ? 1 : 0))
                        sectors[c, row].AssignWallMaterial(1, westWall);
                }
            }

            row--;
            offset--;
        }
    }

    void GeneratePath()
    {
        sectors[0, 0].SetWallHidden(3, true);
        sectors[SIZE - 1, SIZE - 1].SetWallHidden(1, true);

        System.Random rand = new System.Random();
        List<int> prevX = new List<int>(),
            prevY = new List<int>();
        prevX.Add(-1);
        prevY.Add(-1);
        int x = SIZE - 1, y = SIZE - 1;
        do
        {
            if (x == -1 && y == -1)
                break;
            sectors[y, x].SetVisited(true);
            /*Unvisited neighbours, clockwise starting from top
             * If path is invalid, marked as visited*/
            bool[] neighbours = { false, false, false, false };
            if (y == SIZE - 1)
                neighbours[0] = true;
            else if (y == 0)
                neighbours[2] = true;
            if (x == SIZE - 1)
                neighbours[1] = true;
            else if (x == 0)
                neighbours[3] = true;

            bool visited = true, backtrack = false;
            int n = -1;
            while (visited)
            {
                n = rand.Next(0, 4);
                if(n == 0 && !neighbours[0])
                {
                    if (prevY[prevY.Count - 1] == y + 1)
                        continue;
                    visited = sectors[y + 1, x].IsVisited();
                    if (visited)
                    {
                        if ((neighbours[0] || sectors[y + 1, x].IsVisited())
                            && (neighbours[1] || sectors[y, x + 1].IsVisited())
                            && (neighbours[2] || sectors[y - 1, x].IsVisited())
                            && (neighbours[3] || sectors[y, x - 1].IsVisited()))
                        {
                            backtrack = true;
                            break;
                        }
                    }
                }
                else if(n == 2 && !neighbours[2])
                {
                    if (prevY[prevY.Count - 1] == y - 1)
                        continue;
                    visited = sectors[y - 1, x].IsVisited();
                    if (visited)
                    {
                        if ((neighbours[0] || sectors[y + 1, x].IsVisited())
                            && (neighbours[1] || sectors[y, x + 1].IsVisited())
                            && (neighbours[2] || sectors[y - 1, x].IsVisited())
                            && (neighbours[3] || sectors[y, x - 1].IsVisited()))
                        {
                            backtrack = true;
                            break;
                        }
                    }
                }
                else if(n == 1 && !neighbours[1])
                {
                    if (prevX[prevX.Count - 1] == x + 1)
                        continue;
                    visited = sectors[y, x + 1].IsVisited();
                    if (visited)
                    {
                        if ((neighbours[0] || sectors[y + 1, x].IsVisited())
                            && (neighbours[1] || sectors[y, x + 1].IsVisited())
                            && (neighbours[2] || sectors[y - 1, x].IsVisited())
                            && (neighbours[3] || sectors[y, x - 1].IsVisited()))
                        {
                            backtrack = true;
                            break;
                        }
                    }
                }
                else if(n == 3 && !neighbours[3])
                {
                    if (prevX[prevX.Count - 1] == x - 1)
                        continue;
                    visited = sectors[y, x - 1].IsVisited();
                    if (visited)
                    {
                        if ((neighbours[0] || sectors[y + 1, x].IsVisited())
                            && (neighbours[1] || sectors[y, x + 1].IsVisited())
                            && (neighbours[2] || sectors[y - 1, x].IsVisited())
                            && (neighbours[3] || sectors[y, x - 1].IsVisited()))
                        {
                            backtrack = true;
                            break;
                        }
                    }
                }
                //ELSE GO BACK TO PREVIOUS
                else if(prevX[prevX.Count - 1] != -1 && prevY[prevY.Count - 1] != -1)
                {
                    if ((!neighbours[0] && !sectors[y + 1, x].IsVisited())
                        || (!neighbours[1] && !sectors[y, x + 1].IsVisited())
                        || (!neighbours[2] && !sectors[y - 1, x].IsVisited())
                        || (!neighbours[3] && !sectors[y, x - 1].IsVisited()))
                        continue;

                    backtrack = true;
                    break;
                }
                else if(prevX[prevX.Count - 1] == -1 && prevY[prevY.Count - 1] == -1
                    && sectors[SIZE - 2, SIZE - 1].IsVisited() && sectors[SIZE - 1, SIZE - 2].IsVisited())
                {
                    backtrack = true;
                    break;
                }
            }

            if (backtrack)
            {
                int lastIndex = prevX.Count - 1;
                x = prevX[lastIndex];
                y = prevY[lastIndex];
                prevX.RemoveAt(lastIndex);
                prevY.RemoveAt(lastIndex);
                continue;
            }

            prevX.Add(x);
            prevY.Add(y);
            if (n == 0)
                sectors[y++, x].SetWallHidden(0, true);
            else if (n == 2)
                sectors[--y, x].SetWallHidden(0, true);
            else if (n == 1)
                sectors[y, x++].SetWallHidden(1, true);
            else if (n == 3)
                sectors[y, --x].SetWallHidden(1, true);
        } while (x != SIZE - 1 || y != SIZE - 1 ||
            !sectors[SIZE - 2, SIZE - 1].IsVisited() || !sectors[SIZE - 1, SIZE - 2].IsVisited());
    }

    public int[,] GetPath()
    {
        int[,] path = new int[SIZE, SIZE];
        return path;
    }

    public Vector3 GetStartLocation()
    {
        return new Vector3(15 - 15 / SIZE, 0, 15 - 15 / SIZE);
    }

    public int GetSize()
    {
        return SIZE;
    }

    public bool IsSectorHidden(int row, int col, int index)
    {
        if (row == SIZE - 1 && col == SIZE - 1 && index == 1)
            return false;
        return sectors[row, col].IsWallHidden(index);
    }
}
