using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSearch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Do random search if button clicked
    public async void OnClick()
    {
        System.Random Rnd = new System.Random();
        int flag;
        GridData? TemporarySavedGrid = null;

        StopButton.IsButtonDowned = false;
        OperationCountManager.ResetCout();
        TimeManager.ResetTimer();
        TimeManager.StartTimer();

        while (!GridManager.IsGoal(CurrentState.CurrentGrid))
        {
            // When the Force Quit button is pressed
            if (StopButton.IsButtonDowned)
            {
                TimeManager.StopTimer();
                StopButton.IsButtonDowned = false;
                return;
            }

            flag = Rnd.Next(0, 4);
            if (flag == 0)
            {
                TemporarySavedGrid = GridManager.Up(CurrentState.CurrentGrid);
                if (TemporarySavedGrid != null)
                {
                    await OperationCountManager.CountUp();
                    CurrentState.CurrentGrid = (GridData)TemporarySavedGrid;
                    flag = 5;
                }
                flag++;
            }
            if (flag == 1)
            {
                TemporarySavedGrid = GridManager.Down(CurrentState.CurrentGrid);
                if (TemporarySavedGrid != null)
                {
                    await OperationCountManager.CountUp();
                    CurrentState.CurrentGrid = (GridData)TemporarySavedGrid;
                    flag = 5;
                }
                flag++;
            }
            if (flag == 2)
            {
                TemporarySavedGrid = GridManager.Left(CurrentState.CurrentGrid);
                if (TemporarySavedGrid != null)
                {
                    await OperationCountManager .CountUp();
                    CurrentState.CurrentGrid = (GridData)TemporarySavedGrid;
                    flag = 5;
                }
                flag++;
            }
            if (flag == 3)
            {
                TemporarySavedGrid = GridManager.Right(CurrentState.CurrentGrid);
                if (TemporarySavedGrid != null)
                {
                    await OperationCountManager .CountUp();
                    CurrentState.CurrentGrid = (GridData)TemporarySavedGrid;
                    flag = 5;
                }
            }

        }
        TimeManager.StopTimer();
    }
}
