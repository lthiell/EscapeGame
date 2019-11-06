using UnityEngine;
using Valve.VR;

public class MorphMovable : PhysicsMovable
{
    public bool locked;
    public GameObject restingObject;
    public GameObject heldObject;

    protected override void HandleDropSpecific(SteamVR_Behaviour_Pose pose)
    {
        base.HandleDropSpecific(pose);
        ActivateResting();
    }

    protected override void HandlePickupSpecific()
    {
        base.HandlePickupSpecific();
        ActivateHeld();
    }

    public void ActivateResting()
    {
        ToggleObject(false);
    }

    public void ActivateHeld()
    {
        ToggleObject(true);
    }
    
    private void ToggleObject(bool held)
    {
        if (!locked)
        {
            restingObject.SetActive(!held);
            heldObject.SetActive(held);
        }
    }

    public void SetLock(bool locked)
    {
        this.locked = locked;
        this.lockLocalPosition = !locked;
        this.lockLocalRotation = !locked;
        if (IsHeld() && !locked)
        {
            Repick();
        }
    }
}
