using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour
{
    public float countdown = 3.0f;
    public TextMeshProUGUI startText;
    private bool gameStarting;

    // Start is called before the first frame update
    void Start()
    {
        gameStarting = true;

        GameStarter();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        startText.text = (countdown).ToString("START IN: <br> 0");
        GameObject.Find("Player1").GetComponent<Control>().enabled = false;
        GameObject.Find("Player2").GetComponent<Control>().enabled = false;
        if (countdown < 0)
        {
            startText.enabled = false;
            GameObject.Find("Player1").GetComponent<Control>().enabled = true;
            GameObject.Find("Player2").GetComponent<Control>().enabled = true;
            this.enabled = false;
            //gameStarting = false;
        }
    }

    void GameStarter()
    {
        /*if (gameStarting == true)
        {
            //GetComponent<Control>().enabled = false;
            //GetComponent<CoinSpawner>().enabled = false;
            countdown -= Time.deltaTime;
            startText.text = (countdown).ToString("START IN: <br> 0");
            if (countdown < 0)
            {
                startText.enabled = false;
                //gameStarting = false;
            }
        }*/
    }

}
