using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EmergencyButton : Button
{

    public UnityEvent emergencyEvent;

    public override void HandleButtonPress()
    {
        emergencyEvent.Invoke();
    }
}
