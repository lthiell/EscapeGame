using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MagicMovable : Movable

{
    [HideInInspector]
    public Vector3? handPos = null;
    [HideInInspector]
    public Vector3? oldHandPos = null;
    public bool limitPosition = false;
    public bool[] lockAxisAtInitial = new bool[3];
    public Vector3 minPosition;
    public Vector3 maxPosition;

    private bool hintsDisabled = false;
    public List<Hint> associatedHints = new List<Hint>();

    public virtual void Update()
    {
        if (activeHand != null)
        {
            if (this.handPos.HasValue)
            {
                oldHandPos = handPos.Value;
            }
            this.handPos = activeHand.transform.position;

            if (oldHandPos.HasValue)
            {
                transform.position = transform.position + activeHand.transform.position - oldHandPos.Value;
                if (!hintsDisabled)
                {
                    DisableAssociatedHints();
                }
            }
        }
    }

    public override void ApplyOffset(Transform hand)
    {
    }

    protected override void HandleDropSpecific(SteamVR_Behaviour_Pose pose)
    {
        handPos = null;
        oldHandPos = null;
    }

    protected override void HandlePickupSpecific()
    {
    }

    public void LateUpdate()
    {
        if (limitPosition)
        {
            ApplyLimits();
        }

    }

    private void ApplyLimits()
    {
        Vector3 localPos = new Vector3(Mathf.Max(Mathf.Min(transform.position.x, maxPosition.x), minPosition.x)
            , Mathf.Max(Mathf.Min(transform.position.y, maxPosition.y), minPosition.y)
            , Mathf.Max(Mathf.Min(transform.position.z, maxPosition.z), minPosition.z));

        transform.position = localPos;
    }

    public override void StartSpecific()
    {
        for (int i = 0; i < lockAxisAtInitial.Length; i++)
        {
            if (lockAxisAtInitial[i])
            {
                maxPosition[i] = transform.position[i];
                minPosition[i] = maxPosition[i];
            }
        }
    }

    private void DisableAssociatedHints()
    {
        foreach (Hint hint in associatedHints)
        {
            hint.Disable();
        }
        hintsDisabled = true;
    }
}
