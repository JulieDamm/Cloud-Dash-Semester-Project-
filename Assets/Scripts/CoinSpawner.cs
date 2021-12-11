using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;                 // The prefab to spawn.
    public float spawnTime = 1.0f;          // How long between each spawn.
    public Transform[] SpawnLocations;      // An array of spawn points the coin can spawn.

    private List<Transform> possiblelocations;

    public PlayerOneCollectables pO;
    public PlayerTwoCollectables pT;

    private GameObject[] clones;

    // Start is called before the first frame update
    void Start()
    {
        possiblelocations = new List<Transform>();
        RepopulatePossibleLocations();

        /* Run the Spawn function after a delay of the spawnTime and then
           continue to run it after the  same amount of time. */
        InvokeRepeating("Spawn", spawnTime, spawnTime);

        clones = GameObject.FindGameObjectsWithTag("Collectable");
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
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, possiblelocations.Count);

            /* Create an instance of the coin prefab at the randomly selected spawn point's
            position and rotation. */

            Instantiate(Coin, possiblelocations[spawnPointIndex].position, possiblelocations[spawnPointIndex].rotation);

            possiblelocations.RemoveAt(spawnPointIndex);
        }
        else
        {
            RepopulatePossibleLocations();
        }

        if (pO.gameWon)
        {
            foreach (GameObject clone in GameObject.FindGameObjectsWithTag("Collectable"))
            {
                Destroy(clone);
            }

            CancelInvoke("Spawn");
        }

        if (pT.gameWon)
        {
            foreach (GameObject clone in GameObject.FindGameObjectsWithTag("Collectable"))
            {
                Destroy(clone);
            }

            CancelInvoke("Spawn");
        }
    }
}