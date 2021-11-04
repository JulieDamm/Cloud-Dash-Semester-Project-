using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;                 // The prefab to spawn.
    public float spawnTime = 1.0f;          // How long between each spawn.
    public Transform[] SpawnLocations;      // An array of spawn points the coin can spawn.

    public PlayerOneCollectables pO;
    public PlayerTwoCollectables pT;

    // Start is called before the first frame update
    void Start()
    {
        /* Run the Spawn function after a delay of the spawnTime and then
           continue to run it after the  same amount of time. */
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, SpawnLocations.Length);

        /* Create an instance of the coin prefab at the randomly selected spawn point's
        position and rotation. */
        Instantiate(Coin, SpawnLocations[spawnPointIndex].position, SpawnLocations[spawnPointIndex].rotation);

        if (pO.gameWon)
        {
            CancelInvoke("Spawn");
        }

        if (pT.gameWon)
        {
            CancelInvoke("Spawn");
        }

    }

}
