using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphController : MonoBehaviour
{
    public bool invertMorph;

    public List<MorphMovable> morphObjects = new List<MorphMovable>();
    private Dictionary<MorphMovable, int> colliderCounter = new Dictionary<MorphMovable, int>();

    public void Start()
    {
        foreach (MorphMovable morph in morphObjects)
        {
            colliderCounter.Add(morph, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        foreach (MorphMovable morph in morphObjects)
        {
            if (morph.gameObject.Equals(other.gameObject))
            {
                if (morph.IsHeld())
                {
                    UpdateCounter(morph, true);
                    Change(morph, false);
                }
                //morph.SetLock(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (MorphMovable morph in morphObjects)
        {
            if (morph.gameObject.Equals(other.gameObject))
            {
                //morph.SetLock(false);
                if (morph.IsHeld())
                {
                    UpdateCounter(morph, false);
                    Change(morph, true);
                }
            }
        }
    }

    private void UpdateCounter(MorphMovable obj, bool increase)
    {
        int sign = increase ? 1 : -1
            , oldVal = 0;
        colliderCounter.TryGetValue(obj, out oldVal);
        colliderCounter[obj] = oldVal + sign;
    }

    private void Change(MorphMovable obj, bool exit)
    {
        bool rest = !invertMorph;
        int colliderCount = 0;
        colliderCounter.TryGetValue(obj, out colliderCount);
        if (exit)
        {
            rest = !rest;
        }
        print("collidierCount: " + colliderCount);
        if (rest /*&& (colliderCount > 0)*/)
        {
            obj.ActivateResting();
            print("activate Resting");
            obj.SetLock(true);
        }
        if (!rest && true/*(colliderCount == 0)*/) {
            obj.SetLock(false);
            obj.ActivateHeld();
            print("activate Held");
        }
    }
}
