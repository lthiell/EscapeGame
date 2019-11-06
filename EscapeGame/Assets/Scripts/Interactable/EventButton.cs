using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventButton : Button
{

    public UnityEvent buttonEvent;

    public override void HandleButtonPress()
    {
        buttonEvent.Invoke();
    }
}
