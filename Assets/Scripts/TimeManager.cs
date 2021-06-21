using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static Stopwatch sw = new System.Diagnostics.Stopwatch();

    public Text Text;

    private double ExecutionTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExecutionTime = (double)sw.ElapsedMilliseconds / 1000;
        Text.text = "実行時間: " + ExecutionTime.ToString("f3") + "[sec]";
    }

    public static void ResetTimer()
    {
        sw.Restart();
    }

    public static void StartTimer()
    {
        sw.Start();
    }

    public static void StopTimer()
    {
        sw.Stop();
    }
}
