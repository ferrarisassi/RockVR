﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

//OVRGRabber is an inherited class
public class HandGrabbingBehaviour : OVRGrabber
{
    private OVRHand m_hand;
    private float pinchThreshold = 0.7f;

    protected override void Start()
    {
        base.Start();
        m_hand = GetComponent<OVRHand>();
    }

    public override void Update()
    {
        base.Update();
        CheckIndexPinch();
    }

    void CheckIndexPinch()
    {
        float pinchStrenght = m_hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        if(!m_grabbedObj && pinchStrenght> pinchThreshold && m_grabCandidates.Count > 0)
        {
            GrabBegin();
        }
        else if(m_grabbedObj && !(pinchStrenght > pinchThreshold))
        {
            GrabEnd();
        }
    }
}
