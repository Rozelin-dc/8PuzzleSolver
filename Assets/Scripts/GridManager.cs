using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridData
{
    public char[,] Grid;
    public int[] BlankCoordinate;
}

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        CurrentState.Shuffle();
    }
}
