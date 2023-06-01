using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MilliDisplay;
    

    private void OnTriggerEnter(Collider other)
    {
        if (LapTimeManager.SecCount <= 9)
        {
            SecDisplay.GetComponent<TextMeshProUGUI>().text = "0" + LapTimeManager.SecCount + ".";
        }
        else
        {
            SecDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapTimeManager.SecCount + ".";
        }
        if (LapTimeManager.MinCount <= 9)
        {
            MinDisplay.GetComponent<TextMeshProUGUI>().text = "0" + LapTimeManager.MinCount + ".";
        }
        else
        {
            MinDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapTimeManager.MinCount + ".";
        }

        MilliDisplay.GetComponent<TextMeshProUGUI>().text = "" + LapTimeManager.scaledMilliCount;

        LapTimeManager.MinCount = 0;
        LapTimeManager.SecCount = 0;
        LapTimeManager.MilliCount = 0;
        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);
    }
}
