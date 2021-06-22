using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentState : MonoBehaviour
{
    public static GridData CurrentGrid = new GridData();

    public Text Text00;
    public Text Text01;
    public Text Text02;
    public Text Text10;
    public Text Text11;
    public Text Text12;
    public Text Text20;
    public Text Text21;
    public Text Text22;

    // Start is called before the first frame update
    void Start()
    {
        CurrentGrid.Grid = new char[3, 3];
        CurrentGrid.BlankCoordinate = new int[2];
        CurrentGrid.Grid[0, 0] = '2';
        CurrentGrid.Grid[0, 1] = '5';
        CurrentGrid.Grid[0, 2] = '8';
        CurrentGrid.Grid[1, 0] = '3';
        CurrentGrid.Grid[1, 1] = ' ';
        CurrentGrid.Grid[1, 2] = '7';
        CurrentGrid.Grid[2, 0] = '1';
        CurrentGrid.Grid[2, 1] = '6';
        CurrentGrid.Grid[2, 2] = '4';
        CurrentGrid.BlankCoordinate[0] = 2;
        CurrentGrid.BlankCoordinate[1] = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Text00.text = CurrentGrid.Grid[0, 0].ToString();
        Text01.text = CurrentGrid.Grid[0, 1].ToString();
        Text02.text = CurrentGrid.Grid[0, 2].ToString();
        Text10.text = CurrentGrid.Grid[1, 0].ToString();
        Text11.text = CurrentGrid.Grid[1, 1].ToString();
        Text12.text = CurrentGrid.Grid[1, 2].ToString();
        Text20.text = CurrentGrid.Grid[2, 0].ToString();
        Text21.text = CurrentGrid.Grid[2, 1].ToString();
        Text22.text = CurrentGrid.Grid[2, 2].ToString();
    }

    public static void Shuffle()
    {
        System.Random Rnd = new System.Random();
        int x1, y1, x2, y2;
        char Swap;
        for (int i = 0; i < 9; i++)
        {
            x1 = Rnd.Next(0, 3);
            y1 = Rnd.Next(0, 3);
            x2 = Rnd.Next(0, 3);
            y2 = Rnd.Next(0, 3);

            if (CurrentGrid.BlankCoordinate[0] == x1 && CurrentGrid.BlankCoordinate[1] == y1)
            {
                CurrentGrid.BlankCoordinate[0] = x2;
                CurrentGrid.BlankCoordinate[1] = y2;
            }
            if (CurrentGrid.BlankCoordinate[0] == x2 && CurrentGrid.BlankCoordinate[1] == y2)
            {
                CurrentGrid.BlankCoordinate[0] = x1;
                CurrentGrid.BlankCoordinate[1] = y1;
            }

            Swap = CurrentGrid.Grid[x1, y1];
            CurrentGrid.Grid[x1, y1] = CurrentGrid.Grid[x2, y2];
            CurrentGrid.Grid[x2, y2] = Swap;
        }
    }
}
