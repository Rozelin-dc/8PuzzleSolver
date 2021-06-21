using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentState : MonoBehaviour
{
    public static char[,] CurrentGrid = new char[,] { {'2', '5', '8' }, {'3', ' ', '7' }, {'1', '6', '4' } };
    public static int[] BlankCoordinate = new int[] {2, 2 };

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
        
    }

    // Update is called once per frame
    void Update()
    {
        Text00.text = CurrentGrid[0, 0].ToString();
        Text01.text = CurrentGrid[0, 1].ToString();
        Text02.text = CurrentGrid[0, 2].ToString();
        Text10.text = CurrentGrid[1, 0].ToString();
        Text11.text = CurrentGrid[1, 1].ToString();
        Text12.text = CurrentGrid[1, 2].ToString();
        Text20.text = CurrentGrid[2, 0].ToString();
        Text21.text = CurrentGrid[2, 1].ToString();
        Text22.text = CurrentGrid[2, 2].ToString();
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

            if (BlankCoordinate[0] == x1 && BlankCoordinate[1] == y1)
            {
                BlankCoordinate[0] = x2;
                BlankCoordinate[1] = y2;
            }
            if (BlankCoordinate[0] == x2 && BlankCoordinate[1] == y2)
            {
                BlankCoordinate[0] = x1;
                BlankCoordinate[1] = y1;
            }

            Swap = CurrentGrid[x1, y1];
            CurrentGrid[x1, y1] = CurrentGrid[x2, y2];
            CurrentGrid[x2, y2] = Swap;
        }
    }
}
