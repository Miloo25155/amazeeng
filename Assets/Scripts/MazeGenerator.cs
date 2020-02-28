using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Range(5, 100)]
    public int width;
    [Range(5, 100)]
    public int height;
    [Range(1, 10)]
    public int floors;

    public Transform MazeContainer;

    public GameObject FloorCellPrefab;

    public GameObject TopWallPrefab;
    public GameObject BottomWallPrefab;
    public GameObject RightWallPrefab;
    public GameObject LeftWallPrefab;


    public void GenerateMaze()
    {
        this.Reset();

        GameObject[,] maze = new GameObject[width, height];
        MazeCell[,] cells = MazeGeneration.GenerateMaze(width, height);

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                MazeCell cell = cells[x, y];
                Vector3 position = new Vector3(cell.X, 0, cell.Y);

                GameObject cellObject = new GameObject("cell_" + cell.X + "/" + cell.Y);
                cellObject.transform.parent = MazeContainer;
                cellObject.transform.position = position;

                Instantiate(FloorCellPrefab, position, Quaternion.identity, cellObject.transform);
                if (cell.TopWall)
                {
                    Instantiate(TopWallPrefab, position, Quaternion.identity, cellObject.transform);
                }
                if (cell.RightWall)
                {
                    Instantiate(RightWallPrefab, position, Quaternion.identity, cellObject.transform);
                }
                if (cell.BottomWall)
                {
                    Instantiate(BottomWallPrefab, position, Quaternion.identity, cellObject.transform);
                }
                if (cell.LeftWall)
                {
                    Instantiate(LeftWallPrefab, position, Quaternion.identity, cellObject.transform);
                }
            }
        }
    }

    public void Reset()
    {
        for (int i = MazeContainer.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(MazeContainer.GetChild(i).gameObject);
        }
    }
}
