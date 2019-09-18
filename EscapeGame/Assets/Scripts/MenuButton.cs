using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuButton : Button
{
    public UnityEvent action;

    public override void HandleButtonPress()
    {
        action.Invoke();
    }
}
