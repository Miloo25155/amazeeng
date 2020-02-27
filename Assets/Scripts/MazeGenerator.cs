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

    public Transform mazeContainer;

    public GameObject fullCellPrefab;

    public GameObject verticalWayPrefab;
    public GameObject horizontalWayPrefab;

    public GameObject topRightPrefab;
    public GameObject topLeftPrefab;

    public GameObject bottomRightPrefab;
    public GameObject bottomLeftPrefab;

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
                GameObject prefabToUse = fullCellPrefab;

                if (cell.BottomWall && cell.TopWall)
                {                                       ///   _______
                    prefabToUse = horizontalWayPrefab;  ///   
                }                                       ///   _______
                if (cell.LeftWall && cell.RightWall)
                {                                       ///   |      |
                    prefabToUse = verticalWayPrefab;    ///   |      |
                }                                       ///   |      |
                if (cell.TopWall && cell.RightWall)
                {                                       ///    ______
                    prefabToUse = topRightPrefab;       ///          |
                }                                       ///          |
                if (cell.LeftWall && cell.BottomWall)
                {                                       ///    |
                    prefabToUse = bottomLeftPrefab;     ///    |
                }                                       ///    |______
                if (cell.BottomWall && cell.RightWall)
                {                                       ///           |
                    prefabToUse = bottomRightPrefab;    ///           |
                }                                       ///     ______|
                if (cell.LeftWall && cell.TopWall)
                {                                       ///     _______
                    prefabToUse = topLeftPrefab;        ///     |
                }                                       ///     |

                Instantiate(prefabToUse, position, Quaternion.identity, mazeContainer);
            }
        }
    }

    public void Reset()
    {
        foreach (Transform child in mazeContainer.transform)
        {
            DestroyImmediate(child.gameObject);
        }
    }
}
