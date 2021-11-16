using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] PowerUps;
    public float spawnTime = 10.0f;
    public Transform[] SpawnLocations;

    private List<Transform> possiblelocations;

    // Start is called before the first frame update
    void Start()
    {
        possiblelocations = new List<Transform>();
        RepopulatePossibleLocations();

        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void RepopulatePossibleLocations()
    {
        for (int i = 0; i < SpawnLocations.Length; i++)
        {
            possiblelocations.Add(SpawnLocations[i]);
        }

    }

    void Spawn()
    {
        if (possiblelocations.Count > 0)
        {
            int spawnPointIndex = Random.Range(0, possiblelocations.Count);

            Instantiate(PowerUps [Random.Range (0, PowerUps.Length)], possiblelocations[spawnPointIndex].position, possiblelocations[spawnPointIndex].rotation);

            possiblelocations.RemoveAt(spawnPointIndex);
        }
        else
        {
            RepopulatePossibleLocations();
        }
    }
}