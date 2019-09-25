using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public void Rotate()
    {
        gameObject.transform.Rotate(0, 90, 0);
    }

    public bool IsCorrect()
    {
        return gameObject.transform.localRotation.eulerAngles.y % 360 == 0;
    }
}
