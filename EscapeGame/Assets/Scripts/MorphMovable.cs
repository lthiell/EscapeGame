using UnityEngine;
using Valve.VR;

public class MorphMovable : PhysicsMovable
{
    public bool locked;
    public GameObject resting_object;
    public GameObject held_object;

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
            resting_object.SetActive(!held);
            held_object.SetActive(held);
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
