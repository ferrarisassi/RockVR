using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndSpawn : MonoBehaviour
{
    private void DeleteRock(Collider other)
    {
        if (other.tag == "Rock")
        {
            other.SendMessage("DeleteRock", SendMessageOptions.DontRequireReceiver);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        DeleteRock(other);
    }
}
