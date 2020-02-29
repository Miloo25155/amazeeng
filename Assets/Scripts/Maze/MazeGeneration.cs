using System.Collections;
using System.Collections.Generic;

public static class MazeGeneration 
{
    static MazeCell[,] grid;

    static List<MazeCell> stack = new List<MazeCell>();

    public static MazeCell[,] GenerateMaze(int width, int height)
    {
        grid = GenerateGrid(width, height);

        MazeCell current = grid[0, 0];
        RecursivePass(current);

        return grid;
    }

    private static MazeCell[,] GenerateGrid(int width, int height)
    {
        MazeCell[,] grid = new MazeCell[width, height];
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                grid[x, y] = new MazeCell(x, y);
            }
        }
        return grid;
    }

    private static void RecursivePass(MazeCell current)
    {
        current.Visited = true;
        MazeCell next = current.GetRandomUnvisitedNeighbour(grid);
        if (next != null)
        {
            stack.Add(current);

            current.RemoveWalls(next);
            RecursivePass(next);
        }
        else if(stack.Count > 0)
        {
            MazeCell back = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            RecursivePass(back);
        }
    }

    public static void GenerateFloorPassages(List<MazeCell[,]> floors)
    {

    }
}
