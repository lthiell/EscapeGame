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
       return Give(false);
    }

    private bool Give(bool minimalHint)
    {
        if (!used)
        {
            if (!minimalHint) {
                hintLight.enabled = true;
                roomLight.enabled = false;
                sound.Play();
                Invoke("EnableRoomLightAndPlayAudioSource", 6.0f);
            }
            used = true;
            return true;
        }
        return false;
    }

    private void EnableRoomLightAndPlayAudioSource()
    {
        roomLight.enabled = true;
        sound.Play();
    }

    public override void Disable()
    {
        Give(true);
        base.Disable();
    }
}
