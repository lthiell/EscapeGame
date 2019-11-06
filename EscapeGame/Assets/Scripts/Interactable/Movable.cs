using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public abstract class Movable : Interactable
{
    [HideInInspector]
    public Hand activeHand = null;

    public abstract void ApplyOffset(Transform hand);

    public bool IsHeld()
    {
        return activeHand != null;
    }

    public void HandlePickup(Hand hand)
    {
        // already held?
        if (activeHand)
        {
            activeHand.Drop();
        }
        //set active hand
        activeHand = hand;
        HandlePickupSpecific();
    }

    public void HandleDrop(SteamVR_Behaviour_Pose pose)
    {
        HandleDropSpecific(pose);
        activeHand = null;
    }

    protected void Repick()
    {
        Hand hand = this.activeHand;
        this.HandleDrop(hand.GetComponent<SteamVR_Behaviour_Pose>());
        this.HandlePickup(hand);
    }

    protected abstract void HandleDropSpecific(SteamVR_Behaviour_Pose pose);

    protected abstract void HandlePickupSpecific();

    public sealed override bool IsMovable()
    {
        return true;
    }
}
