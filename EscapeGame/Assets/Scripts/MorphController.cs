using System.Collections.Generic;
using UnityEngine;

public class MorphController : MonoBehaviour
{
    public bool invertMorph;

    public List<MorphMovable> morphObjects = new List<MorphMovable>();

    private void OnTriggerStay(Collider other)
    {
        foreach (MorphMovable morph in morphObjects)
        {
            if (morph.gameObject.Equals(other.gameObject))
            {
                if(invertMorph)
                {
                    morph.ActivateHeld();
                } else
                {
                    morph.ActivateResting();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (MorphMovable morph in morphObjects)
        {
            if (morph.gameObject.Equals(other.gameObject))
            {
                if(morph.IsHeld())
                {
                    morph.ActivateHeld();
                } else
                {
                    morph.ActivateResting();
                }
            }
        }
    }

}
