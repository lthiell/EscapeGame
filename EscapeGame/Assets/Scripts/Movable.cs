using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public abstract class Movable : Interactable
{
    [HideInInspector]
    public Hand m_ActiveHand = null;

    public abstract void ApplyOffset(Transform hand);

    public bool IsHeld()
    {
        return m_ActiveHand != null;
    }

    public void HandlePickup(Hand hand)
    {
        // already held?
        if (m_ActiveHand)
        {
            m_ActiveHand.Drop();
        }
        //set active hand
        m_ActiveHand = hand;
        HandlePickupSpecific();
    }

    public void HandleDrop(SteamVR_Behaviour_Pose pose)
    {
        HandleDropSpecific(pose);
        m_ActiveHand = null;
    }

    protected void Repick()
    {
        Hand hand = this.m_ActiveHand;
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
