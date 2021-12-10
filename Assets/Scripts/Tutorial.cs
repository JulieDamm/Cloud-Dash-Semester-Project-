using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public ResetTrigger[] SkyRespawnList;

    // Start is called before the first frame update
    void Start()
    {
        
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
            if (Input.GetKeyDown(KeyCode.Y))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            foreach (ResetTrigger script in SkyRespawnList)
            {
                script.GetComponent<ResetTrigger>().enabled = false;
                script.GetComponentInChildren<ParticleSystem>().Stop();
            }
            GameObject.Find("Player1").GetComponent<Control>().enabled = true;
            GameObject.Find("Player2").GetComponent<Control>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Y))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {

        }
    }
}
