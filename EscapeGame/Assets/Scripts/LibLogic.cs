﻿using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LibLogic : MonoBehaviour
{
    public GameObject keyboard;
    public GameObject keypad;
    public Material unlockedMaterial;
    public GameObject computerBackground;
    public GameObject hallway;

    public GameObject leftHand;
    public GameObject rightHand;
    public VRInputModule inputModule;

    public string menuScene;
    private LevelLoader levelLoader;
    private ActionSetManager ASManager;

    public Door exitDoor;
    private bool exitOpened = false;
    private bool leftHandRay = false;

    private bool computerLocked = true;

    private List<GameObject> rayInputElements;

    private Haptics haptics;

    public void Start()
    {
        gameObject.AddComponent(typeof(LevelLoader));
        levelLoader = GetComponent<LevelLoader>();
        ASManager = GetComponent<ActionSetManager>();
        rayInputElements = new List<GameObject>(new GameObject[] { keyboard, keypad });
        haptics = GetComponent<Haptics>();
        haptics.SetInputSource(leftHandRay ? SteamVR_Input_Sources.LeftHand : SteamVR_Input_Sources.RightHand);
    }

    public void OpenExit()
    {
        exitOpened = true;
        exitDoor.OpenDoor();
        hallway.SetActive(true);
    }

    public void LoadMenu()
    {
        levelLoader.LoadLevel("Menu");
    }

    public bool IsOpen()
    {
        return exitOpened;
    }

    public void UnlockComputer()
    {
        print("Computer is unlocked.");
        keyboard.SetActive(false);
        ASManager.ActivateTeleportSet();
        computerLocked = false;
        MeshRenderer meshRenderer = computerBackground.GetComponent<MeshRenderer>();
        meshRenderer.material = unlockedMaterial;
    }

    public bool IsComputerLocked()
    {
        return computerLocked;
    }

    public void ToggleRayHand()
    {
        leftHandRay = !leftHandRay;
        Transform pointerLeft = leftHand.transform.Find("PR_Pointer_Left");
        Transform pointerRight = rightHand.transform.Find("PR_Pointer_Right");

        if (leftHandRay)
        {
            SelectPointer(pointerLeft, pointerRight, SteamVR_Input_Sources.LeftHand);
        } else
        {
            SelectPointer(pointerRight, pointerLeft, SteamVR_Input_Sources.RightHand);
        }
    }


    private void SelectPointer(Transform activePointer, Transform inactivePointer, SteamVR_Input_Sources activeHand)
    {
        activePointer.GetComponent<LineRenderer>().enabled = true;
        inactivePointer.GetComponent<LineRenderer>().enabled = false;
        activePointer.transform.Find("Dot").GetComponent<MeshRenderer>().enabled = true;
        inactivePointer.transform.Find("Dot").GetComponent<MeshRenderer>().enabled = false;
        Camera camera = activePointer.GetComponent<Camera>();
        foreach(GameObject elem in rayInputElements)
        {
            elem.GetComponent<Canvas>().worldCamera = camera;
        }
        inputModule.m_Camera = camera;
        inputModule.m_TargetSource = activeHand;
        haptics.SetInputSource(activeHand);
    }
}
