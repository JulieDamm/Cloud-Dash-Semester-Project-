using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public TutResetSky[] SkyRespawnList;

    // Start is called before the first frame update
    void Start()
    {
        foreach (TutResetSky script in SkyRespawnList)
        {
            script.GetComponent<TutResetSky>().enabled = false;
            script.GetComponentInChildren<ParticleSystem>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if(popUpIndex == 0)
        {
            GameObject.Find("Player1").GetComponent<Control>().enabled = false;
            GameObject.Find("Player2").GetComponent<Control>().enabled = false;
            GameObject.Find("TutorialManager").GetComponent<CoinSpawner>().enabled = false;
            
            if (Input.GetKeyDown(KeyCode.Y))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            
            GameObject.Find("Player1").GetComponent<Control>().enabled = true;
            GameObject.Find("Player2").GetComponent<Control>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Y))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            GameObject.Find("TutorialManager").GetComponent<CoinSpawner>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Y))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            GameObject.Find("TutorialManager").GetComponent<PowerUpSpawner>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Y))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
            GameObject.Find("Player1").GetComponent<Player1Skills>().enabled = true;
            GameObject.Find("Player2").GetComponent<Player2Skills>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Y))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            foreach (TutResetSky script in SkyRespawnList)
            {
                script.GetComponent<TutResetSky>().enabled = true;
                
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                popUpIndex++;
            }
        }
    }
}
