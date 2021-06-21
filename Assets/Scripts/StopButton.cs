using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    private static bool IsButtonDowned = false;

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
        IsButtonDowned = true;
    }

    public static bool GetIsButtonDowned()
    {
        return IsButtonDowned;
    }

    public static void ResetIsButtonDowned()
    {
        IsButtonDowned = false;
    }
}
