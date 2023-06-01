using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapTimeManager : MonoBehaviour
{
    public static int MinCount;
    public static int SecCount;
    public static float MilliCount;
    public static string MilliDisplay;
    public static int scaledMilliCount;

    public GameObject MinBox;
    public GameObject SecBox;
    public GameObject MilliBox;
    void Update()
    {
        MilliCount+=10*Time.deltaTime;
        scaledMilliCount=Mathf.RoundToInt(MilliCount);
        MilliDisplay = scaledMilliCount.ToString("F0");
        MilliBox.GetComponent<TextMeshProUGUI>().text=""+MilliDisplay;

        if (MilliCount >= 10)
        {
            MilliCount = 0;
            SecCount += 1;
        }

        if (SecCount <= 9)
        {
            SecBox.GetComponent<TextMeshProUGUI>().text = "0" + SecCount+".";
        }
        else
        {
            SecBox.GetComponent<TextMeshProUGUI>().text = "" + SecCount+".";
        }

        if (SecCount >= 60)
        {
            SecCount = 0;
            MinCount += 1;
        }

        if (MinCount <= 9)
        {
            MinBox.GetComponent<TextMeshProUGUI>().text = "0" + MinCount + ":";
        }
        else
        {
            MinBox.GetComponent<TextMeshProUGUI>().text = "" + MinCount + ":"; 
        }
    }
}
