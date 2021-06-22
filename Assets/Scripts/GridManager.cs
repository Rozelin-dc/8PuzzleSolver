using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridData
{
    public char[,] Grid; // Grid[y, x]
    public int[] BlankCoordinate; // BlankCoordinate[0] = y, BlankCoordinate[1] = x
}

public class GridManager : MonoBehaviour
{
    private static GridData GoalGrid = new GridData();

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        CurrentState.Shuffle();
    }

    public static bool IsTwoGridDataEqal(GridData Grid1, GridData Grid2)
    {
        if (Grid1.BlankCoordinate[0] != Grid2.BlankCoordinate[0]) return false;
        if (Grid1.BlankCoordinate[1] != Grid2.BlankCoordinate[1]) return false;

        if (Grid1.Grid[0, 0] != Grid2.Grid[0, 0]) return false;
        if (Grid1.Grid[0, 1] != Grid2.Grid[0, 1]) return false;
        if (Grid1.Grid[0, 2] != Grid2.Grid[0, 2]) return false;
        if (Grid1.Grid[1, 0] != Grid2.Grid[1, 0]) return false;
        if (Grid1.Grid[1, 1] != Grid2.Grid[1, 1]) return false;
        if (Grid1.Grid[1, 2] != Grid2.Grid[1, 2]) return false;
        if (Grid1.Grid[2, 0] != Grid2.Grid[2, 0]) return false;
        if (Grid1.Grid[2, 1] != Grid2.Grid[2, 1]) return false;
        if (Grid1.Grid[2, 2] != Grid2.Grid[2, 2]) return false;

        return true;
    }

    public static bool IsGoal(GridData Grid)
    {
        return IsTwoGridDataEqal(GoalGrid, Grid);
    }

    public static GridData? Up(GridData Grid)
    {
        if (Grid.BlankCoordinate[0] == 2) return null;

        Grid.Grid[Grid.BlankCoordinate[0], Grid.BlankCoordinate[1]] = Grid.Grid[Grid.BlankCoordinate[0] + 1, Grid.BlankCoordinate[1]];
        Grid.Grid[Grid.BlankCoordinate[0] + 1, Grid.BlankCoordinate[1]] = ' ';
        Grid.BlankCoordinate[0] += 1;
        return Grid;
    }

    public static GridData? Down(GridData Grid)
    {
        if (Grid.BlankCoordinate[0] == 0) return null;

        Grid.Grid[Grid.BlankCoordinate[0], Grid.BlankCoordinate[1]] = Grid.Grid[Grid.BlankCoordinate[0] - 1, Grid.BlankCoordinate[1]];
        Grid.Grid[Grid.BlankCoordinate[0] - 1, Grid.BlankCoordinate[1]] = ' ';
        Grid.BlankCoordinate[0] -= 1;
        return Grid;
    }

    public static GridData? Left(GridData Grid)
    {
        if (Grid.BlankCoordinate[1] == 2) return null;

        Grid.Grid[Grid.BlankCoordinate[0], Grid.BlankCoordinate[1]] = Grid.Grid[Grid.BlankCoordinate[0], Grid.BlankCoordinate[1] + 1];
        Grid.Grid[Grid.BlankCoordinate[0], Grid.BlankCoordinate[1] + 1] = ' ';
        Grid.BlankCoordinate[1] += 1;
        return Grid;
    }

    public static GridData? Right(GridData Grid)
    {
        if (Grid.BlankCoordinate[1] == 0) return null;

        Grid.Grid[Grid.BlankCoordinate[0], Grid.BlankCoordinate[1]] = Grid.Grid[Grid.BlankCoordinate[0], Grid.BlankCoordinate[1] - 1];
        Grid.Grid[Grid.BlankCoordinate[0], Grid.BlankCoordinate[1] - 1] = ' ';
        Grid.BlankCoordinate[1] -= 1;
        return Grid;
    }
}
