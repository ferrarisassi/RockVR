using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGrabbableScript : OVRGrabbable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        //GetComponent<CardController>().OnGrabEnd();
    }
}
