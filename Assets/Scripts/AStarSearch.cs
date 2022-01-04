using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStarSearch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Do A* search if button clicked
    public async void OnClick()
    {
        GridData? TemporarySavedGrid = null;
        GridDataWithCost TargetGridDataWithCost;
        GridDataWithCost TemporarySavedGridWithCost = new GridDataWithCost();
        HashSet<string> VisitedGrid = new HashSet<string>();
        List<GridDataWithCost> Open = new List<GridDataWithCost>();

        VisitedGrid.Add(CurrentState.CurrentGrid.GridToString());

        TemporarySavedGridWithCost.GridData = CurrentState.CurrentGrid.Copy();
        TemporarySavedGridWithCost.CostUpToCurrent = 0;
        TemporarySavedGridWithCost.ExpectedTotalCost = GridManager.Heuristic(TemporarySavedGridWithCost.GridData);

        Open.Add(TemporarySavedGridWithCost);

        StopButton.IsButtonDowned = false;
        OperationCountManager.ResetCout();
        TimeManager.ResetTimer();
        TimeManager.StartTimer();

        while (!GridManager.IsGoal(CurrentState.CurrentGrid) && Open.Count() > 0)
        {
            // When the Force Quit button is pressed
            if (StopButton.IsButtonDowned)
            {
                TimeManager.StopTimer();
                StopButton.IsButtonDowned = false;
                return;
            }

            TargetGridDataWithCost = Open[0];
            Open.RemoveAt(0);

            await OperationCountManager.CountUp();
            CurrentState.CurrentGrid = TargetGridDataWithCost.GridData.Copy();

            if (GridManager.IsGoal(CurrentState.CurrentGrid))
            {
                TimeManager.StopTimer();
                return;
            }

            TemporarySavedGrid = GridManager.Up(TargetGridDataWithCost.GridData);
            if (TemporarySavedGrid != null && !VisitedGrid.Contains(TemporarySavedGrid?.GridToString()))
            {
                TemporarySavedGridWithCost = new GridDataWithCost();
                TemporarySavedGridWithCost.GridData = ((GridData)TemporarySavedGrid).Copy();
                TemporarySavedGridWithCost.CostUpToCurrent = TargetGridDataWithCost.CostUpToCurrent + 1;
                TemporarySavedGridWithCost.ExpectedTotalCost =
                    TemporarySavedGridWithCost.CostUpToCurrent + GridManager.Heuristic(TemporarySavedGridWithCost.GridData);

                Open.Add(TemporarySavedGridWithCost);
                VisitedGrid.Add(TemporarySavedGrid?.GridToString());
            }

            TemporarySavedGrid = GridManager.Down(TargetGridDataWithCost.GridData);
            if (TemporarySavedGrid != null && !VisitedGrid.Contains(TemporarySavedGrid?.GridToString()))
            {
                TemporarySavedGridWithCost = new GridDataWithCost();
                TemporarySavedGridWithCost.GridData = ((GridData)TemporarySavedGrid).Copy();
                TemporarySavedGridWithCost.CostUpToCurrent = TargetGridDataWithCost.CostUpToCurrent + 1;
                TemporarySavedGridWithCost.ExpectedTotalCost =
                    TemporarySavedGridWithCost.CostUpToCurrent + GridManager.Heuristic(TemporarySavedGridWithCost.GridData);

                Open.Add(TemporarySavedGridWithCost);
                VisitedGrid.Add(TemporarySavedGrid?.GridToString());
            }

            TemporarySavedGrid = GridManager.Left(TargetGridDataWithCost.GridData);
            if (TemporarySavedGrid != null && !VisitedGrid.Contains(TemporarySavedGrid?.GridToString()))
            {
                TemporarySavedGridWithCost = new GridDataWithCost();
                TemporarySavedGridWithCost.GridData = ((GridData)TemporarySavedGrid).Copy();
                TemporarySavedGridWithCost.CostUpToCurrent = TargetGridDataWithCost.CostUpToCurrent + 1;
                TemporarySavedGridWithCost.ExpectedTotalCost =
                    TemporarySavedGridWithCost.CostUpToCurrent + GridManager.Heuristic(TemporarySavedGridWithCost.GridData);

                Open.Add(TemporarySavedGridWithCost);
                VisitedGrid.Add(TemporarySavedGrid?.GridToString());
            }

            TemporarySavedGrid = GridManager.Right(TargetGridDataWithCost.GridData);
            if (TemporarySavedGrid != null && !VisitedGrid.Contains(TemporarySavedGrid?.GridToString()))
            {
                TemporarySavedGridWithCost = new GridDataWithCost();
                TemporarySavedGridWithCost.GridData = ((GridData)TemporarySavedGrid).Copy();
                TemporarySavedGridWithCost.CostUpToCurrent = TargetGridDataWithCost.CostUpToCurrent + 1;
                TemporarySavedGridWithCost.ExpectedTotalCost =
                    TemporarySavedGridWithCost.CostUpToCurrent + GridManager.Heuristic(TemporarySavedGridWithCost.GridData);

                Open.Add(TemporarySavedGridWithCost);
                VisitedGrid.Add(TemporarySavedGrid?.GridToString());
            }

            // Sort Open
            Open.OrderBy(Value => Value.ExpectedTotalCost);
        }
        TimeManager.StopTimer();
    }
}
