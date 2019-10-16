using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    public float interval;
    public float firstInterval;
    public List<Hint> hint_list = new List<Hint>();

    private bool firstHint = true;
    
    void Start()
    {
        StartTimer();
    }

    private void GiveHint()
    {
        bool success = false;
        while (!success && hint_list.Count > 0)
        {
            Hint hint = hint_list[0];
            success = hint.Give();
            hint_list.RemoveAt(0);
            firstHint = false;
        } 
    }

    public void StartTimer()
    {
            InvokeRepeating("GiveHint", firstHint ? firstInterval : interval, interval);
    }

    public void RestartTimer()
    {
        CancelInvoke();
        StartTimer();
    }

    public void AddHint(Hint hint)
    {
        hint_list.Insert(0, hint);
    }
}
