using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    public float interval = 30.0f;
    public List<Hint> hint_list = new List<Hint>();
    
    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GiveHint()
    {
        print("Hallo Sparkle!");
        bool success = false;
        while (!success && hint_list.Count > 0)
        {
            Hint hint = hint_list[0];
            success = hint.Give();
            hint_list.RemoveAt(0);
        } 
    }

    public void StartTimer()
    {
        InvokeRepeating("GiveHint", interval, interval);
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
