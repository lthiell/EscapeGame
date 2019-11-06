using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    public float interval;
    public float firstInterval;
    public List<Hint> hintList = new List<Hint>();

    public Timer timer;

    private bool firstHint = true;
    
    void Start()
    {
        StartTimer();
    }

    public void GiveHint()
    {
        bool success = false;
        while (!success && hintList.Count > 0)
        {
            Hint hint = hintList[0];
            success = hint.Give();
            hintList.RemoveAt(0);
            firstHint = false;
        }
        if (success)
        {
            SetTimer(interval);
        }
    }

    public void StartTimer()
    {
            float nextInterval = firstHint ? firstInterval : interval;
            InvokeRepeating("GiveHint", nextInterval, interval);
            SetTimer(nextInterval);
    }

    private bool AnyActiveHints()
    {
        bool active = false;
        foreach (Hint hint in hintList)
        {
            active |= hint.enabled;
        }
        return active;
    }

    private void SetTimer(float timeSpan)
    {
        if (timer)
        {
            if (AnyActiveHints())
            {
                timer.SetCountDown(timeSpan);
            } else
            {
                timer.SetCountDown(0.0f);
            }
        }

        if (!AnyActiveHints())
        {
            CancelInvoke();
        }
    }
    public void RestartTimer()
    {
        CancelInvoke();
        StartTimer();
    }

    public void AddHint(Hint hint)
    {
        hintList.Insert(0, hint);
    }
}
