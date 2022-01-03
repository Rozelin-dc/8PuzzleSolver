using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedySearch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Do greedy search if button clicked
    public async void OnClick()
    {
        System.Random Rnd = new System.Random();
        GridData? TemporarySavedGrid = null;
        int UpProbability, DownProbability, LeftProbability, RightProbability, TotalProbability;
        double p, Probability;

        StopButton.ResetIsButtonDowned();
        OperationCountManager.ResetCout();
        TimeManager.ResetTimer();
        TimeManager.StartTimer();

        while (!GridManager.IsGoal(CurrentState.CurrentGrid))
        {
            // When the Force Quit button is pressed
            if (StopButton.GetIsButtonDowned())
            {
                TimeManager.StopTimer();
                StopButton.ResetIsButtonDowned();
                return;
            }

            TotalProbability = 0;

            TemporarySavedGrid = GridManager.Up(CurrentState.CurrentGrid);
            if (TemporarySavedGrid == null)
            {
                UpProbability = 0;
            }
            else
            {
                UpProbability = 36 - GridManager.Heuristic((GridData)TemporarySavedGrid);
                TotalProbability += UpProbability;
            }

            TemporarySavedGrid = GridManager.Down(CurrentState.CurrentGrid);
            if (TemporarySavedGrid == null)
            {
                DownProbability = 0;
            }
            else
            {
                DownProbability = 36 - GridManager.Heuristic((GridData)TemporarySavedGrid);
                TotalProbability += DownProbability;
            }

            TemporarySavedGrid = GridManager.Left(CurrentState.CurrentGrid);
            if (TemporarySavedGrid == null)
            {
                LeftProbability = 0;
            }
            else
            {
                LeftProbability = 36 - GridManager.Heuristic((GridData)TemporarySavedGrid);
                TotalProbability += LeftProbability;
            }

            TemporarySavedGrid = GridManager.Right(CurrentState.CurrentGrid);
            if (TemporarySavedGrid == null)
            {
                RightProbability = 0;
            }
            else
            {
                RightProbability = 36 - GridManager.Heuristic((GridData)TemporarySavedGrid);
                TotalProbability += RightProbability;
            }

            p = Rnd.NextDouble();
            Probability = 0;
            if(p <= (Probability += (double)UpProbability / TotalProbability) && UpProbability != 0)
            {
                await OperationCountManager.CountUp();
                CurrentState.CurrentGrid = (GridData)GridManager.Up(CurrentState.CurrentGrid);
            }
            else if (p <= (Probability += (double)DownProbability / TotalProbability) && DownProbability != 0)
            {
                await OperationCountManager.CountUp();
                CurrentState.CurrentGrid = (GridData)GridManager.Down(CurrentState.CurrentGrid);
            }
            else if (p <= (Probability += (double)LeftProbability / TotalProbability) && LeftProbability != 0)
            {
                await OperationCountManager.CountUp();
                CurrentState.CurrentGrid = (GridData)GridManager.Left(CurrentState.CurrentGrid);
            }
            else if (p <= (Probability += (double)RightProbability / TotalProbability) && RightProbability != 0)
            {
                await OperationCountManager.CountUp();
                CurrentState.CurrentGrid = (GridData)GridManager.Right(CurrentState.CurrentGrid);
            }
        }
        TimeManager.StopTimer();
    }
}
