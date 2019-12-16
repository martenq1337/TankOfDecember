using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Text Counter;

    private void OnGUI()
    {
        if (!ControllerManager.Activated)
        {
            float timeToLeft = Mathf.Round(ControllerManager.SleepTime - ControllerManager.Timer);
            Counter.text = timeToLeft.ToString();
        }
        else
            Counter.enabled = false;
    }
}
