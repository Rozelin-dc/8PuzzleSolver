using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridData
{
    public char[,] Grid; // Grid[y, x]
    public int[] BlankCoordinate; // BlankCoordinate[0] = y, BlankCoordinate[1] = x

    public string GridToString()
    {
        string data = "";
        data += Grid[0, 0].ToString();
        data += Grid[0, 1].ToString();
        data += Grid[0, 2].ToString();
        data += Grid[1, 0].ToString();
        data += Grid[1, 1].ToString();
        data += Grid[1, 2].ToString();
        data += Grid[2, 0].ToString();
        data += Grid[2, 1].ToString();
        data += Grid[2, 2].ToString();

        return data;
    }

    public GridData Copy()
    {
        GridData NewStruct = new GridData();
        NewStruct.Grid = (char[,])Grid.Clone();
        NewStruct.BlankCoordinate = (int[])BlankCoordinate.Clone();

        return NewStruct;
    }

    public override int GetHashCode()
    {
        return Grid.GetHashCode() ^ BlankCoordinate.GetHashCode();
    }

    public override bool Equals(object Obj)
    {
        var Other = Obj as GridData?;
        if (Other == null) return false;

        if (this.BlankCoordinate[0] != Other?.BlankCoordinate[0]) return false;
        if (this.BlankCoordinate[1] != Other?.BlankCoordinate[1]) return false;

        if (this.Grid[0, 0] != Other?.Grid[0, 0]) return false;
        if (this.Grid[0, 1] != Other?.Grid[0, 1]) return false;
        if (this.Grid[0, 2] != Other?.Grid[0, 2]) return false;
        if (this.Grid[1, 0] != Other?.Grid[1, 0]) return false;
        if (this.Grid[1, 1] != Other?.Grid[1, 1]) return false;
        if (this.Grid[1, 2] != Other?.Grid[1, 2]) return false;
        if (this.Grid[2, 0] != Other?.Grid[2, 0]) return false;
        if (this.Grid[2, 1] != Other?.Grid[2, 1]) return false;
        if (this.Grid[2, 2] != Other?.Grid[2, 2]) return false;

        return true;
    }
}

public struct GridDataWithCost
{
    public GridData GridData;
    public int CostUpToCurrent;
    public int ExpectedTotalCost;
}

public class GridManager : MonoBehaviour
{
    private static GridData GoalGrid = new GridData();

    // key: characters on the board, value: value[0] = y, value[1] = x
    private static Dictionary<char, int[]> GoalGridCoordinateData = new Dictionary<char, int[]>();

    // Start is called before the first frame update
    void Start()
    {
        GoalGrid.Grid = new char[3, 3];
        GoalGrid.BlankCoordinate = new int[2];
        GoalGrid.Grid[0, 0] = '1';
        GoalGrid.Grid[0, 1] = '2';
        GoalGrid.Grid[0, 2] = '3';
        GoalGrid.Grid[1, 0] = '4';
        GoalGrid.Grid[1, 1] = '5';
        GoalGrid.Grid[1, 2] = '6';
        GoalGrid.Grid[2, 0] = '7';
        GoalGrid.Grid[2, 1] = '8';
        GoalGrid.Grid[2, 2] = ' ';
        GoalGrid.BlankCoordinate[0] = 2;
        GoalGrid.BlankCoordinate[1] = 2;

        GoalGridCoordinateData['1'] = new int[] { 0, 0 };
        GoalGridCoordinateData['2'] = new int[] { 0, 1 };
        GoalGridCoordinateData['3'] = new int[] { 0, 2 };
        GoalGridCoordinateData['4'] = new int[] { 1, 0 };
        GoalGridCoordinateData['5'] = new int[] { 1, 1 };
        GoalGridCoordinateData['6'] = new int[] { 1, 2 };
        GoalGridCoordinateData['7'] = new int[] { 2, 0 };
        GoalGridCoordinateData['8'] = new int[] { 2, 1 };
        GoalGridCoordinateData[' '] = new int[] { 2, 2 };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        CurrentState.Shuffle();
    }

    public static bool IsGoal(GridData Grid)
    {
        return GoalGrid.Equals(Grid);
    }

    public static int Heuristic(GridData Grid)
    {
        int ans = 0;
        int[] CorrectCorrdinate;

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                CorrectCorrdinate = GoalGridCoordinateData[Grid.Grid[y, x]];
                ans += Math.Abs(y - CorrectCorrdinate[0]);
                ans += Math.Abs(x - CorrectCorrdinate[1]);
            }
        }

        return ans;
    }

    public static GridData? Up(GridData Grid)
    {
        if (Grid.BlankCoordinate[0] == 2) return null;

        GridData CopyedGrid = Grid.Copy();

        CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0], CopyedGrid.BlankCoordinate[1]] =
            CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0] + 1, CopyedGrid.BlankCoordinate[1]];
        CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0] + 1, CopyedGrid.BlankCoordinate[1]] = ' ';
        CopyedGrid.BlankCoordinate[0] += 1;

        return CopyedGrid;
    }

    public static GridData? Down(GridData Grid)
    {
        if (Grid.BlankCoordinate[0] == 0) return null;

        GridData CopyedGrid = Grid.Copy();

        CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0], CopyedGrid.BlankCoordinate[1]] =
            CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0] - 1, CopyedGrid.BlankCoordinate[1]];
        CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0] - 1, CopyedGrid.BlankCoordinate[1]] = ' ';
        CopyedGrid.BlankCoordinate[0] -= 1;

        return CopyedGrid;
    }

    public static GridData? Left(GridData Grid)
    {
        if (Grid.BlankCoordinate[1] == 2) return null;

        GridData CopyedGrid = Grid.Copy();

        CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0], CopyedGrid.BlankCoordinate[1]] =
            CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0], CopyedGrid.BlankCoordinate[1] + 1];
        CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0], CopyedGrid.BlankCoordinate[1] + 1] = ' ';
        CopyedGrid.BlankCoordinate[1] += 1;

        return CopyedGrid;
    }

    public static GridData? Right(GridData Grid)
    {
        if (Grid.BlankCoordinate[1] == 0) return null;

        GridData CopyedGrid = Grid.Copy();

        CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0], CopyedGrid.BlankCoordinate[1]] =
            CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0], CopyedGrid.BlankCoordinate[1] - 1];
        CopyedGrid.Grid[CopyedGrid.BlankCoordinate[0], CopyedGrid.BlankCoordinate[1] - 1] = ' ';
        CopyedGrid.BlankCoordinate[1] -= 1;

        return CopyedGrid;
    }
}
