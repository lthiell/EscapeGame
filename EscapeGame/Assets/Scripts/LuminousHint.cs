using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuminousHint : Hint
{
    public Light hintLight;
    public Light roomLight;
    public AudioSource sound;

    public override bool Give()
    {
        bool res = Give(false);
        used = true;
        return res;
    }

    private bool Give(bool minimalHint)
    {
        if (!used)
        {
            if (!minimalHint) {
                roomLight.enabled = false;
                sound.Play();
                Invoke("EnableRoomLight", 6.0f);
            }
            hintLight.enabled = true;
            return true;
        }
        return false;
    }

    private void EnableRoomLight()
    {
        roomLight.enabled = true;
    }

    public override void Disable()
    {
        Give(true);
        base.Disable();
    }
}
