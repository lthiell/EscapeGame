using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Keyboard : PointerUI
{
    public TextValidator validator;

    public Text displayArea = null;
    private bool hidePassword = true;
    private static readonly string EMPTY = "";
    private static readonly string ASTERIC = "*";

    protected string currentText = EMPTY;

    protected virtual void AddToText(Key key)
    {
        currentText += key.GetText();
        AppendToDisplayText(key.GetText());
    }

    private void AppendToDisplayText(string addon)
    {
        if (hidePassword)
        {
            for (int i = 0; i < addon.Length; i++)
            {
                AddToDisplayArea(ASTERIC);
            }
        }
        else
        {
            AddToDisplayArea(addon);
        }
    }

    private void SetDisplayText()
    {
        if (hidePassword)
        {
            SetDisplayAreaText(EMPTY);
            for (int i = 0; i < currentText.Length; i++)
            {
                AddToDisplayArea(ASTERIC);
            }
        } else
        {
            SetDisplayAreaText(currentText);
        }
    }

    public void HandleKeyPress(Key key)
    {
        switch(key.GetKeyType())
        {
            case Key.KeyType.normal:
                AddToText(key);
                break;
            case Key.KeyType.submit:
                Submit();
                Clear();
                break;
            case Key.KeyType.show:
                hidePassword = !hidePassword;
                SetDisplayText();
                break;
            case Key.KeyType.delete:
                if(displayArea != null && displayArea.text.Length > 0)
                {
                    currentText = currentText.Substring(0, displayArea.text.Length - 1);
                    SetDisplayText();
                }
                break;
        }
    }


    protected void Submit()
    {
        validator.Validate(currentText);
    }

    private void Clear()
    {
        currentText = EMPTY;
        SetDisplayText();
    }

    private void AddToDisplayArea(string s)
    {
        if(displayArea != null)
        {
            displayArea.text += s;
        }
    }

    private void SetDisplayAreaText(string s)
    {
        if (displayArea != null)
        {
            displayArea.text = s;
        }
    }
}
