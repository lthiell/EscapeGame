using System;
using UnityEngine;
using Valve.VR;

public class Haptics : MonoBehaviour
{

    public SteamVR_Action_Vibration hapticAction;
    //public Func<SteamVR_Input_Sources> HandGetter;
    private SteamVR_Input_Sources inputSource;

    public void SetInputSource(SteamVR_Input_Sources inputSource)
    {
        this.inputSource = inputSource;
    }


    /**
     *<param name="frequency">How often the haptic motor should bounce (0 - 320 in hz. The lower end being more useful)</param>
      <param name="amplitude">How intense the haptic action should be (0 - 1)</param>
     */
    private void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)
    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
    }

    public void ButtonFeedback()
    {
        Pulse(0.08f, 120, 0.8f, inputSource);
    }
}
