using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Keyboard : MonoBehaviour
{

    public TextValidator validator;
    public List<GameObject> pointerObjects;

    public Text displayArea = null;
    private bool hidePassword = true;

    protected string currentText = "";



    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Hand"))
            return;
        foreach (GameObject obj in pointerObjects)
        {
            obj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Hand"))
            return;

        foreach (GameObject obj in pointerObjects)
        {
            obj.SetActive(false);
        }
    }

    protected virtual void AddToText(Key key)
    {
        currentText += key.GetText();
        AppendToDisplayText(key.GetText());
        /**string debug = "addToText (key): " + "(" + key.GetKeyType() + ") ";
        if (key.GetKeyType().Equals(Key.KeyType.normal))
        {
            debug += key.GetText();
        }
        print(debug);*/
    }

    private void AppendToDisplayText(string addon)
    {
        if (hidePassword)
        {
            for (int i = 0; i < addon.Length; i++)
            {
                AddToDisplayArea("*");
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
            SetDisplayAreaText("");
            for (int i = 0; i < currentText.Length; i++)
            {
                AddToDisplayArea("*");
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
        currentText = "";
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
