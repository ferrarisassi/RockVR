using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI tMPro;

    public List<GameObject> Rocks = new List<GameObject>();
    [SerializeField] private GameObject[] rockPrefabs;
    [SerializeField] private Transform rockSpawner;

    [SerializeField] private GameObject targetSpawner;
    [SerializeField] private GameObject targetPrefab;

    public int points = 0;

    float T = 0;

    private int gravityIndex = 0;
    private string where = "Moon";

    private GameObject newTarget;

    [SerializeField] AudioSource radioSoundEffect;
    [SerializeField] AudioSource hitSoundEffect;
    [SerializeField] AudioSource gravitySoundEffect;
    [SerializeField] AudioSource rockSoundEffect;

    [SerializeField] string MarsSceneName;
    [SerializeField] string MoonSceneName;

    private void Start()
    {
        InstantiateRock();
    }

    private void Update()
    {
        T += Time.deltaTime;
        
        changeText("Points: " + points.ToString() +
                   "\nTime: " + ((int)T).ToString() +
                   "\nGravity: " + where);

        if (OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Four))
        {
            InstantiateRock();
        }

            if (OVRInput.GetDown(OVRInput.Button.One) || OVRInput.GetDown(OVRInput.Button.Three))
        {
            gravitySoundEffect.Play();
            gravityIndex += 1;
            if (gravityIndex > 4) gravityIndex = 0;
            if (gravityIndex == 0)
            {
                Physics.gravity = new Vector3(0, -1.62f, 0);
                where = "Moon";
            }
            else if (gravityIndex == 1)
            {
                Physics.gravity = new Vector3(0, -9.81f, 0);
                where = "Earth";
            }
            else if (gravityIndex == 2)
            {
                Physics.gravity = new Vector3(0, -3.72f, 0);
                where = "Mars";
            }
            else if (gravityIndex == 3)
            {
                Physics.gravity = new Vector3(0, -24.79f, 0);
                where = "Jupiter";
            }
            else if (gravityIndex == 4)
            {
                Physics.gravity = new Vector3(0, -10.44f, 0);
                where = "Saturn";
            }
        }
    }

    public void changeText(string s)
    {
        tMPro.text = s;
    }

    public void InstantiateRock()
    {
        if (Rocks.Count < 3)
        {
            rockSoundEffect.Play();
            Instantiate(rockPrefabs[Random.Range(0, rockPrefabs.Length)], rockSpawner.position, Quaternion.identity);
        }
    }

    public void DestroyRock(GameObject rock)
    {
        Rocks.Remove(rock);
    }

    public void addPoints(int pointsToAdd)
    {
        points += pointsToAdd;

        if(points == 5)
        {
            radioSoundEffect.Play();
        }

        if (points > 10)
        {
            points = 0;
            T = 0;
            if(SceneManager.GetActiveScene().name == MoonSceneName)
            {
                SceneManager.LoadScene(MarsSceneName);
            }
        }
    }

    public void PlayHitSound()
    {
        hitSoundEffect.Play();
    }

    public void SpawnTarget()
    {
        var n = 0.5f;
        Vector3 pos = targetSpawner.transform.position + new Vector3(Random.Range(-n,n), Random.Range(-n, n), Random.Range(-n, n));
        newTarget = Instantiate(targetPrefab, pos, Quaternion.identity, null);
    }
}
