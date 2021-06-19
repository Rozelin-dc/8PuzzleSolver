using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentState : MonoBehaviour
{
    public static int[,] CurrentGrid = new int[,] { {2, 5, 8 }, {3, 0, 7 }, {1, 6, 4 } };
    public static int[] BlankCoordinate = new int[] {2, 2 };

    public GameObject Text00;
    public GameObject Text01;
    public GameObject Text02;
    public GameObject Text10;
    public GameObject Text11;
    public GameObject Text12;
    public GameObject Text20;
    public GameObject Text21;
    public GameObject Text22;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text00.GetComponent<Text>().text = CurrentGrid[0, 0].ToString();
        Text01.GetComponent<Text>().text = CurrentGrid[0, 1].ToString();
        Text02.GetComponent<Text>().text = CurrentGrid[0, 2].ToString();
        Text10.GetComponent<Text>().text = CurrentGrid[1, 0].ToString();
        Text11.GetComponent<Text>().text = CurrentGrid[1, 1].ToString();
        Text12.GetComponent<Text>().text = CurrentGrid[1, 2].ToString();
        Text20.GetComponent<Text>().text = CurrentGrid[2, 0].ToString();
        Text21.GetComponent<Text>().text = CurrentGrid[2, 1].ToString();
        Text22.GetComponent<Text>().text = CurrentGrid[2, 2].ToString();
    }

    public static void Shuffle()
    {

    }
}
