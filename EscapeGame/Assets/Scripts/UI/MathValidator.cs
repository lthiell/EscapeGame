using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MathValidator : PointerUI
{

    public Color DEFAULT_COLOR, CORRECT_COLOR, SELECTED_COLOR;

    private enum Status
    {
        SELECTED, NOT_SELECTED, CORRECT
    }

    private static readonly string DEFAULT_TEXT = "X";

    private bool locked = false;

    private Dictionary<Text, Status> areaStatus = new Dictionary<Text, Status>();
    private Dictionary<Text, string> solutions = new Dictionary<Text, string>();
    public List<string> solutionsList;
    public List<Text> textsList;

    public UnityEvent onAllCorrect;


    private Text currentText;

    public void Start()
    {
        for (int i = 0; i < solutionsList.Count; i++)
        {
            solutions.Add(textsList[i], solutionsList[i]);
        }
        bool first = true;
        foreach(Text t in solutions.Keys)
        {
            if (first)
            {
                SetSelected(t);
                first = false;
            }
            else
            {
                SetNotSelected(t);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Hand"))
            return;
        /* Damit der Strahl für das Tablet noch nicht aktiviert wird, bevor der Spieler es gefunden hat, ist zuerst nur ein 
         * sehr kleiner Collider aktiv, sobald dieser einmal getriggert wird, werden alle Collider aktiviert. */
        BoxCollider[] boxColliders = GetComponents<BoxCollider>();
        foreach(BoxCollider bc in boxColliders)
        {
            bc.enabled = true;
        }
    }

    protected virtual void AddToText(Key key)
    {
        int res = 0;
        bool isInt = int.TryParse(currentText.text, out res);
        if (isInt && res < 100) {
            currentText.text += key.GetText();
        } else
        {
            currentText.text = key.GetText();
        }
    }

    public void HandleKeyPress(Key key)
    {
        if (!locked)
        {
            switch (key.GetKeyType())
            {
                case Key.KeyType.normal:
                    AddToText(key);
                    break;
                case Key.KeyType.submit:
                default:
                    Submit();
                    break;
            }
        }
    }

    private void CheckAllSolutions()
    {
        bool done = true;
        Text nextText = null;
        foreach (Text text in areaStatus.Keys)
        {
            bool correct = areaStatus[text].Equals(Status.CORRECT);
            done &= correct;
            if (!nextText && !correct)
            {
                nextText = text;
            }
        }
        if (done)
        {
            locked = true;
            onAllCorrect.Invoke();
        } else
        {
            SetSelected(nextText);
        }

    }

    private void Submit()
    {
        if(currentText && currentText.text.Equals(solutions[currentText]))
        {
            SetCorrect(currentText);
            CheckAllSolutions();
        } else
        {
            SetSelected(currentText);
        }
    }

    private void SetSelected(Text inText)
    {
        if (currentText)
        {
            SetNotSelected(currentText);
        }
        currentText = inText;
        areaStatus[currentText] = Status.SELECTED;
        currentText.text = "";
        currentText.color = SELECTED_COLOR;
    }

    private void SetCorrect(Text inText)
    {
        if (inText.Equals(currentText))
        {
            currentText = null;
        }
        areaStatus[inText] = Status.CORRECT;
        inText.color = CORRECT_COLOR;
    }

    private void SetNotSelected(Text inText)
    {
        if (inText.Equals(currentText))
        {
            currentText = null;
        }
        areaStatus[inText] = Status.NOT_SELECTED;
        inText.text = DEFAULT_TEXT;
        inText.color = DEFAULT_COLOR;
    }


    public void SetInput(Text text)
    {
        if (!locked && textsList.Contains(text) && !Status.CORRECT.Equals(areaStatus[text]))
        {
            Submit();
            SetSelected(text);
        }
    }

    /* Da es ggf. mehrere Trigger-Collider gibt, müssen alle beim vollständigen Lösen deaktiviert werden. */
    public void RemoveAllTriggers()
    {
        BoxCollider[] boxColliders = GetComponents<BoxCollider>();
        foreach (BoxCollider bc in boxColliders)
        {
            if(bc.isTrigger)
            {
                bc.enabled = false;
            }

        }
    }
}
