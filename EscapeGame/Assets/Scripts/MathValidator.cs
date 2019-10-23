using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathValidator : PointerUI
{

    public Color DEFAULT_COLOR, CORRECT_COLOR, SELECTED_COLOR;

    private enum Status
    {
        SELECTED, NOT_SELECTED, CORRECT
    }

    private static string DEFAULT_TEXT = "X";

    private bool locked = false;


    private Dictionary<Text, Status> areaStatus = new Dictionary<Text, Status>();
    private Dictionary<Text, string> solutions = new Dictionary<Text, string>();
    public List<string> solutionsList;
    public List<Text> textsList;



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
                areaStatus.Add(t, Status.SELECTED);
                first = false;
                currentText = t;
            }
            else
            {
                areaStatus.Add(t, Status.NOT_SELECTED);
                t.text = DEFAULT_TEXT;
            }
        }
    }


    protected virtual void AddToText(Key key)
    {
        currentText.text = key.GetText();
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
        foreach (Text text in areaStatus.Keys)
        {
            done &= areaStatus[text].Equals(Status.CORRECT);
        }
        if (done)
        {
            locked = true;
        }
    }

    private void Submit()
    {
        // TODO
        if(currentText.text.Equals(solutions[currentText]))
        {
            SetCurrentStatus(Status.CORRECT);
            CheckAllSolutions();
        } else
        {
            currentText.text = DEFAULT_TEXT;
        }
    }


    private void SetCurrentStatus(Status status)
    {
        SetStatus(currentText, status);
    }
    private void SetStatus(Text inText, Status status)
    {
        areaStatus[inText] = status;
        switch (status)
        {
            case Status.NOT_SELECTED:
                currentText.text = DEFAULT_TEXT;
                currentText.color = DEFAULT_COLOR;
                break;
            case Status.SELECTED:
                currentText.text = "";
                currentText.color = SELECTED_COLOR;
                foreach (Text text in solutions.Keys)
                {
                    if (!areaStatus[text].Equals(Status.CORRECT))
                    {
                        SetStatus(text, Status.NOT_SELECTED);
                    }
                }
                break;
            case Status.CORRECT:
                currentText.color = CORRECT_COLOR;
                break;
        }
    }

    public void SetInput(Text text)
    {
        if (!locked && textsList.Contains(text))
        {
            Submit();
            if (!Status.CORRECT.Equals(areaStatus[text]))
            {
                currentText = text;
                SetCurrentStatus(Status.SELECTED);
            }
        }
    }
}
