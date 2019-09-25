using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class PuzzleController : PointerUI
{
    public UnityEvent onPuzzleSolved;
    public List<PuzzlePiece> pieces;

    public void Check()
    {
        bool solved = true;
        foreach(PuzzlePiece p in pieces)
        {
            if(!p.IsCorrect())
            {
                solved = false;
            }
        }
        if(solved)
        {
            onPuzzleSolved.Invoke();
        }
    }
}
