using UnityEngine;
using Valve.VR;

public class ActionSetManager : MonoBehaviour
{
    public SteamVR_ActionSet teleportSet;
    public SteamVR_ActionSet keyboardSet;
   
    public void ToggleKeyboardSet()
    {
        if (teleportSet.IsActive())
        {
            teleportSet.Deactivate();
            keyboardSet.Activate();
        }
        else
        {
            keyboardSet.Deactivate();
            teleportSet.Activate();
        }
    }

    public void ActivateTeleportSet()
    {
        keyboardSet.Deactivate();
        teleportSet.Activate();
    }

    public void ActivateKeyboardSet()
    {
        teleportSet.Deactivate();
        keyboardSet.Activate();
    }
}
