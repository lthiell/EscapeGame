using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(string scene)
    {
        SteamVR_LoadLevel.Begin(scene);
    }
}
