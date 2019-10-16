using Valve.VR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericHint : Hint
{
    public UnityEvent action;


    public override bool Give()
    {
        if (!used) {
            action.Invoke();
            used = true;
            return true;
        } else {
            return false;
        }
    }
}
