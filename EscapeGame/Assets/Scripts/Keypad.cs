﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Keyboard
{

    public int keyLength = 4;

    protected override void AddToText(Key key)
    {
        base.AddToText(key);
        print("currentText: " + currentText);
        if(currentText.Length == keyLength)
        {
            print("Submitting");
            Submit();
            currentText = currentText.Substring(1);
        }
    }
}
