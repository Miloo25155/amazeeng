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

    public Transform LevelContainer;

    public GameObject FloorCellPrefab;

    public GameObject TopWallPrefab;
    public GameObject BottomWallPrefab;
    public GameObject RightWallPrefab;
    public GameObject LeftWallPrefab;

    public void Start()
    {
        GenerateLevels();
    }

    public void GenerateLevels()
    {
        this.Reset();

        List<MazeCell[,]> levels = new List<MazeCell[,]>(floors);
        for (int i = 0; i < floors; i++)
        {
            MazeCell[,] floor = MazeGeneration.GenerateMaze(width, height);
            levels.Add(floor);
        }

        MazeGeneration.GenerateFloorPassages(levels);

        this.InstantiateLevels(levels);
    }

    public void InstantiateLevels(List<MazeCell[,]> levels)
    {
        for (int l = 0; l < levels.Count; l++)
        {
            MazeCell[,] cells = levels[l];

            GameObject levelObject = new GameObject("level_" + l);
            levelObject.transform.parent = LevelContainer;
            levelObject.transform.position = new Vector3(-width / 2, l, -height / 2);

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    MazeCell cell = cells[x, y];
                    Vector3 position = new Vector3(cell.X, 0, cell.Y);

                    GameObject cellObject = new GameObject("cell_" + cell.X + "/" + cell.Y);
                    cellObject.transform.parent = levelObject.transform;
                    cellObject.transform.localPosition = position;

                    Instantiate(FloorCellPrefab, cellObject.transform, false);
                    if (cell.TopWall)
                    {
                        Instantiate(TopWallPrefab, cellObject.transform, false);
                    }
                    if (cell.RightWall)
                    {
                        Instantiate(RightWallPrefab, cellObject.transform, false);
                    }
                    if (cell.BottomWall)
                    {
                        Instantiate(BottomWallPrefab, cellObject.transform, false);
                    }
                    if (cell.LeftWall)
                    {
                        Instantiate(LeftWallPrefab, cellObject.transform, false);
                    }
                }
            }
        }
    }

    public void Reset()
    {
        for (int i = LevelContainer.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(LevelContainer.GetChild(i).gameObject);
        }
    }
}
