using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;
    public Haptics haptics;

    public Color OUTLINE_COLOR;

    private SteamVR_Behaviour_Pose m_Pose = null;
    public FixedJoint m_Joint = null;

    private Interactable m_CurrentInteractable = null;
    private Interactable m_HighlightedInteractable;
    private List<Interactable> m_ContactInteractables = new List<Interactable>();

    private GameObject hand;

    private void Start()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        m_Joint = GetComponent<FixedJoint>();
    }

    private void Update()
    {
        if (m_GrabAction.GetStateDown(m_Pose.inputSource))
        {
            Pickup();
        } else if (m_GrabAction.GetStateUp(m_Pose.inputSource))
        {
            Drop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable nearest = null;
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        m_ContactInteractables.Add(other.gameObject.GetComponent<Interactable>());

        // evtl. schon vorhandene Outline entfernen
        if (m_HighlightedInteractable != null)
        {
            m_HighlightedInteractable.OnHoverExit(m_Pose.inputSource);
        }
        // neues nahestes Interactable highlighten
        m_HighlightedInteractable = null;
        nearest = getNearest();
        if (nearest != null && nearest.showOutline)
        {
            m_HighlightedInteractable = nearest;
        }
        if (m_HighlightedInteractable != null)
        {
            m_HighlightedInteractable.OnHoverEnter(m_Pose.inputSource);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        // Interactable aus der Liste der Interactables in der Nähe entfernen
        m_ContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());

        // Wenn das entfernte Interactable das gehighlightete ist, dann Highlight entfernen
        if (other.gameObject.GetComponent<Interactable>() != null
            && other.gameObject.GetComponent<Interactable>().Equals(m_HighlightedInteractable))
        {
            m_HighlightedInteractable.OnHoverExit(m_Pose.inputSource);
            m_HighlightedInteractable = null;
        }
    }

    public void Pickup()
    {
        m_CurrentInteractable = getNearest();
        if (!m_CurrentInteractable)
            return;

        if (m_CurrentInteractable is Button)
        {
            ((Button)m_CurrentInteractable).HandleButtonPress();
        }
        else if (m_CurrentInteractable.IsMovable())
        {
            ((Movable)m_CurrentInteractable).HandlePickup(this);
        }

        m_CurrentInteractable.DisableHint();
        m_CurrentInteractable.DisableLoopedSounds();
    }


    public void Drop()
    {
        if (!m_CurrentInteractable)
            return;

        if (m_CurrentInteractable.IsMovable())
        {
            if (((Movable)m_CurrentInteractable).activeHand == this)
            {
                ((Movable)m_CurrentInteractable).HandleDrop(m_Pose);
            }
        }
        m_CurrentInteractable = null;

    }

    private Interactable getNearest()
    {
        Interactable nearest = null;
        float minDist = float.MaxValue;
        float dist = 0.0f;
        foreach (Interactable i in m_ContactInteractables)
        {
            dist = (i.transform.position - transform.position).sqrMagnitude;
            if (dist < minDist)
            {
                minDist = dist;
                nearest = i;
            }

        }
        return nearest;
    }

    public GameObject getCurrentInteractable()
    {
        if (m_CurrentInteractable == null)
        {
            return null;
        }
        return m_CurrentInteractable.gameObject;
    }
}
