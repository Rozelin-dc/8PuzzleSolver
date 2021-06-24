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
        System.Random Rnd = new System.Random();
        GridData? TemporarySavedGrid = null;
        GridDataWithCost TargetGridDataWithCost, TemporarySavedGridWithCost;
        Dictionary<GridData, bool> VisitedGrid = new Dictionary<GridData, bool>();
        List<GridDataWithCost> Open = new List<GridDataWithCost>();

        TemporarySavedGridWithCost.GridData = CurrentState.CurrentGrid;
        TemporarySavedGridWithCost.CostUpToCurrent = 0;
        TemporarySavedGridWithCost.ExpectedTotalCost = GridManager.Heuristic(TemporarySavedGridWithCost.GridData);

        Open.Add(TemporarySavedGridWithCost);

        StopButton.ResetIsButtonDowned();
        OperationCountManager.ResetCout();
        TimeManager.ResetTimer();
        TimeManager.StartTimer();

        while (!GridManager.IsGoal(CurrentState.CurrentGrid) && Open.Count() > 0)
        {
            // When the Force Quit button is pressed
            if (StopButton.GetIsButtonDowned())
            {
                TimeManager.StopTimer();
                StopButton.ResetIsButtonDowned();
                return;
            }

            TargetGridDataWithCost = Open[0];
            Open.RemoveAt(0);

            await OperationCountManager.CountUp();
            CurrentState.CurrentGrid = TargetGridDataWithCost.GridData;

            if (GridManager.IsGoal(CurrentState.CurrentGrid))
            {
                TimeManager.StopTimer();
                return;
            }

            TemporarySavedGrid = GridManager.Up(TargetGridDataWithCost.GridData);
            if (TemporarySavedGrid != null && !VisitedGrid.ContainsKey((GridData)TemporarySavedGrid))
            {
                TemporarySavedGridWithCost.GridData = (GridData)TemporarySavedGrid;
                TemporarySavedGridWithCost.CostUpToCurrent = TargetGridDataWithCost.CostUpToCurrent + 1;
                TemporarySavedGridWithCost.ExpectedTotalCost =
                    TemporarySavedGridWithCost.CostUpToCurrent + GridManager.Heuristic(TemporarySavedGridWithCost.GridData);

                Open.Add(TemporarySavedGridWithCost);
                VisitedGrid[(GridData)TemporarySavedGrid] = true;
            }

            TemporarySavedGrid = GridManager.Down(TargetGridDataWithCost.GridData);
            if (TemporarySavedGrid != null && !VisitedGrid.ContainsKey((GridData)TemporarySavedGrid))
            {
                TemporarySavedGridWithCost.GridData = (GridData)TemporarySavedGrid;
                TemporarySavedGridWithCost.CostUpToCurrent = TargetGridDataWithCost.CostUpToCurrent + 1;
                TemporarySavedGridWithCost.ExpectedTotalCost =
                    TemporarySavedGridWithCost.CostUpToCurrent + GridManager.Heuristic(TemporarySavedGridWithCost.GridData);

                Open.Add(TemporarySavedGridWithCost);
                VisitedGrid[(GridData)TemporarySavedGrid] = true;
            }

            TemporarySavedGrid = GridManager.Left(TargetGridDataWithCost.GridData);
            if (TemporarySavedGrid != null && !VisitedGrid.ContainsKey((GridData)TemporarySavedGrid))
            {
                TemporarySavedGridWithCost.GridData = (GridData)TemporarySavedGrid;
                TemporarySavedGridWithCost.CostUpToCurrent = TargetGridDataWithCost.CostUpToCurrent + 1;
                TemporarySavedGridWithCost.ExpectedTotalCost =
                    TemporarySavedGridWithCost.CostUpToCurrent + GridManager.Heuristic(TemporarySavedGridWithCost.GridData);

                Open.Add(TemporarySavedGridWithCost);
                VisitedGrid[(GridData)TemporarySavedGrid] = true;
            }

            TemporarySavedGrid = GridManager.Right(TargetGridDataWithCost.GridData);
            if (TemporarySavedGrid != null && !VisitedGrid.ContainsKey((GridData)TemporarySavedGrid))
            {
                TemporarySavedGridWithCost.GridData = (GridData)TemporarySavedGrid;
                TemporarySavedGridWithCost.CostUpToCurrent = TargetGridDataWithCost.CostUpToCurrent + 1;
                TemporarySavedGridWithCost.ExpectedTotalCost =
                    TemporarySavedGridWithCost.CostUpToCurrent + GridManager.Heuristic(TemporarySavedGridWithCost.GridData);

                Open.Add(TemporarySavedGridWithCost);
                VisitedGrid[(GridData)TemporarySavedGrid] = true;
            }

            // Sort Open
            Open.OrderBy(Value => Value.ExpectedTotalCost);
        }
        TimeManager.StopTimer();
    }
}
