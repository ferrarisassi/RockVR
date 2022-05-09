using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGrabbable : OVRGrabbable
{
    private RockController rockController;
    
    protected override void Start()
    {
        base.Start();
        rockController = GetComponent<RockController>();
    }

    public void OnMouseDown()
    {
        Debug.Log("here");
        GetComponent<RockController>().OnGrabBeggin();
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        GetComponent<RockController>().OnGrabBeggin();
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
    }
}
