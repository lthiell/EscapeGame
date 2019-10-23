using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;

    public bool countDown = false;
    public float countDownStart = 0;

    private float startTime;


    public void Start()
    {
        startTime = Time.time;   
    }

    public float GetTime()
    {
        if (countDown)
        {
            return countDownStart + (startTime - Time.time);
        } else
        {
            return Time.time - startTime;
        }
    }

    public string GetDisplayTime()
    {
        float time = GetTime();
        System.DateTime dt = System.DateTime.MinValue;
        dt = dt.AddSeconds(time > 0 ? time : 0);
        return dt.ToString("HH:mm:ss");
    }

    private void FixedUpdate()
    {
        if(text)
        {
            text.text = GetDisplayTime();
        }
    }

    public void SetCountDown(float cd)
    {
        countDownStart = cd;
        Start();
    }
}
