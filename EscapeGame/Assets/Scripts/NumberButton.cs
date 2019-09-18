using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberButton : Button
{
    public int digit;
    public CodeValidator numberReceiver;

    public override void HandleButtonPress()
    {
        numberReceiver.EnterNumber(digit);
    }
}
