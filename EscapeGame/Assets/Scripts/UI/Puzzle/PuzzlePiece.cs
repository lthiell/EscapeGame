using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    // Ein Puzzleteil gilt als richtig gedreht, wenn seine Rotation diesem Wert entspricht
    private static readonly int CORRECT_ROTATION = 0;

    public void Rotate()
    {
        gameObject.transform.Rotate(0, 90, 0);
    }

    public bool IsCorrect()
    {
        return gameObject.transform.localRotation.eulerAngles.y % 360 == CORRECT_ROTATION;
    }
}
