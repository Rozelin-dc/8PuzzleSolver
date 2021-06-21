using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class OperationCountManager : MonoBehaviour
{
    public Text Text;

    private static int OperationCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "操作回数: " + OperationCount + "回";
    }

    public static async void CountUp()
    {
        await Task.Delay(50);
        OperationCount++;
    }

    public static int GetOperationVount()
    {
        return OperationCount;
    }
}
