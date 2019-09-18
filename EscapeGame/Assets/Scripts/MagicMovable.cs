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


    public virtual void Update()
    {
        if (m_ActiveHand != null)
        {
            if (this.handPos.HasValue)
            {
                oldHandPos = handPos.Value;
            }
            this.handPos = new Vector3(m_ActiveHand.transform.position.x, m_ActiveHand.transform.position.y, m_ActiveHand.transform.position.z);

            if (oldHandPos.HasValue)
            {
                transform.position = new Vector3(
                    transform.position.x + (m_ActiveHand.transform.position.x - oldHandPos.Value.x),
                    transform.position.y + (m_ActiveHand.transform.position.y - oldHandPos.Value.y),
                    transform.position.z + (m_ActiveHand.transform.position.z - oldHandPos.Value.z));
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
                maxPosition[i] = transform.position[i] + 0.00f;
                minPosition[i] = maxPosition[i] - 0.00f;
            }
        }
    }
}
