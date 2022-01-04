using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadthFirstSearch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Do breadth first search if button clicked
    public async void OnClick()
    {
        HashSet<string> VisitedGrid = new HashSet<string>();
        Queue<GridData> Que = new Queue<GridData>();
        VisitedGrid.Add(CurrentState.CurrentGrid.GridToString());
        Que.Enqueue(CurrentState.CurrentGrid.Copy());

        GridData TargetGridData;
        GridData? TemporarySavedGrid;

        StopButton.IsButtonDowned = false;
        OperationCountManager.ResetCout();
        TimeManager.ResetTimer();
        TimeManager.StartTimer();

        while (!GridManager.IsGoal(CurrentState.CurrentGrid) && Que.Count > 0)
        {
            // When the Force Quit button is pressed
            if (StopButton.IsButtonDowned)
            {
                TimeManager.StopTimer();
                StopButton.IsButtonDowned = false;
                return;
            }

            TargetGridData = Que.Dequeue();

            await OperationCountManager.CountUp();
            CurrentState.CurrentGrid = TargetGridData.Copy();

            if (GridManager.IsGoal(CurrentState.CurrentGrid))
            {
                TimeManager.StopTimer();
                return;
            }

            TemporarySavedGrid = GridManager.Up(TargetGridData);
            if (TemporarySavedGrid != null && !VisitedGrid.Contains(TemporarySavedGrid?.GridToString()))
            {
                Que.Enqueue((GridData)TemporarySavedGrid);
                VisitedGrid.Add(TemporarySavedGrid?.GridToString());
            }

            TemporarySavedGrid = GridManager.Down(TargetGridData);
            if (TemporarySavedGrid != null && !VisitedGrid.Contains(TemporarySavedGrid?.GridToString()))
            {
                Que.Enqueue((GridData)TemporarySavedGrid);
                VisitedGrid.Add(TemporarySavedGrid?.GridToString());
            }

            TemporarySavedGrid = GridManager.Left(TargetGridData);
            if (TemporarySavedGrid != null && !VisitedGrid.Contains(TemporarySavedGrid?.GridToString()))
            {
                Que.Enqueue((GridData)TemporarySavedGrid);
                VisitedGrid.Add(TemporarySavedGrid?.GridToString());
            }

            TemporarySavedGrid = GridManager.Right(TargetGridData);
            if (TemporarySavedGrid != null && !VisitedGrid.Contains(TemporarySavedGrid?.GridToString()))
            {
                Que.Enqueue((GridData)TemporarySavedGrid);
                VisitedGrid.Add(TemporarySavedGrid?.GridToString());
            }
        }

        TimeManager.StopTimer();
    }
}
