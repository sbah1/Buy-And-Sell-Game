using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIME : MonoBehaviour
{
    public static float time = 0;
    public Text timertext;

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timertext.text = "Time left: " + time.ToString("N0");

            if (time < 0.001)
            {
                time = 0;
                timertext.text = "Time left: 0";
            }
        }
    }
}
