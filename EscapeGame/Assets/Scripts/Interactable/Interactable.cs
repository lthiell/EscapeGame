using UnityEngine;
using Valve.VR;

public class Interactable : MonoBehaviour
{
    public static Color OUTLINE_COLOR = Color.yellow;
    public bool showOutline = false;
    private Outline outline;

    public void Start()
    {
        // Outline initialisieren, falls nötig
        if (showOutline)
        {
            outline = gameObject.AddComponent<Outline>();
            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = OUTLINE_COLOR;
            outline.OutlineWidth = 5f;
            outline.enabled = false;
        }
        StartSpecific();
    }

    public virtual void StartSpecific() { }

    public virtual void OnHoverEnter(SteamVR_Input_Sources inputSource)
    {
        if (showOutline)
        {
            outline.enabled = true;
        }

    }

    public virtual void OnHoverExit(SteamVR_Input_Sources inputSource)
    {
        if (showOutline)
        {
            outline.enabled = false;
        }
    }

    public virtual bool IsMovable()
    {
        return false;
    }

    public void DisableLoopedSounds()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.loop)
            {
                audioSource.enabled = false;
            }
        }
    }

    public void DisableHint()
    {
        Hint hint = gameObject.GetComponent<Hint>();
        if (hint)
        {
            hint.Disable();
        }
    }
}
