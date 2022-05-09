using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        if(GM == null) GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        this.transform.LookAt(player.transform);
        this.transform.Rotate(new Vector3(0, 90, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            GM.PlayHitSound();
            DeleteRock(collision.gameObject);
            GM.addPoints(1);
            GM.SpawnTarget();
            Destroy(this.gameObject);
        }
    }

    private void DeleteRock(GameObject other)
    {
        other.SendMessage("DeleteRock", SendMessageOptions.DontRequireReceiver);
    }
}
