﻿using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsMovable : Movable
{
    public Vector3 m_Offset = Vector3.zero;
    public Vector3 m_RotationOffset = Vector3.zero;
    public bool lockLocalPosition = false;
    public bool lockLocalRotation = false;
    public GameObject optionalParent = null;


    public override void ApplyOffset(Transform hand)
    {
        Vector3 locScale = transform.localScale;
        Transform parent = transform.parent;

        transform.SetParent(hand);
        if (lockLocalRotation)
        {
            transform.localRotation = Quaternion.identity;
            transform.Rotate(m_RotationOffset, Space.Self);
        }
        if (lockLocalPosition)
        {
            transform.localPosition = m_Offset;
        }

        if (optionalParent == null)
        {
            transform.parent = parent;
        } else
        {
            transform.parent = optionalParent.transform;
            optionalParent = null;
        }
        //transform.localScale = locScale;

    }

    protected override void HandleDropSpecific(SteamVR_Behaviour_Pose pose)
    {
        Rigidbody targetBody = GetComponent<Rigidbody>();
        targetBody.velocity = pose.GetVelocity();
        targetBody.angularVelocity = pose.GetAngularVelocity();

        // detach
        m_ActiveHand.m_Joint.connectedBody = null;
    }

    protected override void HandlePickupSpecific()
    {
        //position
        ApplyOffset(m_ActiveHand.transform);

        //attach
        Rigidbody targetBody = GetComponent<Rigidbody>();
        m_ActiveHand.m_Joint.connectedBody = targetBody;
    }

    public override void StartSpecific()
    {
    }
}
