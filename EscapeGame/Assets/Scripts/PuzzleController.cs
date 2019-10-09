using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

public class PuzzleController : PointerUI
{
    public UnityEvent onPuzzleSolved;
    public List<PuzzlePiece> pieces;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Check()
    {
        DisableAudioSource();
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

    private void DisableAudioSource()
    {
        if (audioSource)
        {
            audioSource.enabled = false;
        }
    }
}
