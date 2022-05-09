using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        if (GM == null) GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.Rocks.Add(this.gameObject);
    }

    public void DeleteRock()
    {
        this.tag = "Deafult";
        GM.DestroyRock(this.gameObject);
    }

    public void OnGrabBeggin()
    {
        GM.Invoke("InstantiateRock", 0.5f);
    }
}
