using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Valve.VR;

public class MenuLogic : MonoBehaviour
{
    public string libraryScene;
    public GameObject menuPlayer;

    private LevelLoader levelLoader;

    public void Start()
    {
        this.gameObject.AddComponent(typeof(LevelLoader));
        levelLoader = this.gameObject.GetComponent<LevelLoader>();
    }

    public void LoadLibrary()
    {
        levelLoader.LoadLevel(libraryScene);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                 Application.OpenURL(webplayerQuitURL);
        #else
                 Application.Quit();
        #endif
    }
}
