using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{
    public int X { get; set; }
    public int Y { get; set; }

    public bool Visited { get; set; }

    public bool TopWall { get; set; }
    public bool RightWall { get; set; }
    public bool BottomWall { get; set; }
    public bool LeftWall { get; set; }

    public MazeCell(int x, int y)
    {
        X = x;
        Y = y;
        Visited = false;

        TopWall = RightWall = BottomWall = LeftWall = true;
    }

    public MazeCell GetRandomUnvisitedNeighbour(MazeCell[,] grid)
    {
        List<MazeCell> neighbours = new List<MazeCell>();

        MazeCell top = Y < grid.GetLength(1) - 1 ? grid[X, Y + 1] : null;
        MazeCell right = X < grid.GetLength(0) - 1 ? right = grid[X + 1, Y] : null;
        MazeCell bottom = Y > 0 ? grid[X, Y - 1] : null;
        MazeCell left = X > 0 ? grid[X - 1, Y] : null;

        if (top != null && !top.Visited) { neighbours.Add(top); }
        if (right != null && !right.Visited) { neighbours.Add(right); }
        if (bottom != null && !bottom.Visited) { neighbours.Add(bottom); }
        if (left != null && !left.Visited) { neighbours.Add(left); }

        if(neighbours.Count > 0)
        {
            int index = Random.Range(0, neighbours.Count);
            return neighbours[index];
        }
        return null;
    }

    public void RemoveWalls(MazeCell neighbour)
    {
        //top neighbour
        if(X == neighbour.X && Y < neighbour.Y)
        {
            this.TopWall = false;
            neighbour.BottomWall = false;
        }
        //right neighbour
        else if (X < neighbour.X && Y == neighbour.Y)
        {
            this.RightWall = false;
            neighbour.LeftWall = false;
        }
        //bottom neighbour
        else if (X == neighbour.X && Y > neighbour.Y)
        {
            this.BottomWall = false;
            neighbour.TopWall = false;
        }
        //left neighbour
        else if (X > neighbour.X && Y == neighbour.Y)
        {
            this.LeftWall = false;
            neighbour.RightWall = false;
        }
    }
}