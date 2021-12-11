using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutPlayer2Collect : MonoBehaviour
{
    public int playerTwoCount;
    public TextMeshProUGUI Player2Count;
    public TextMeshProUGUI Player2Total;
    private int playerTwoCurrentCount;
    public int playerTwoTotal;

    public int maxCoinHeld;
    public Sprite fullCoin;
    public Sprite emptyCoin;
    public Image[] coins;

    private SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        playerTwoCount = 0;
        playerTwoTotal = 0;

        SetPlayerTwoCountText();
        SetPlayerTwoTotalText();
    }

    public void SetPlayerTwoCountText()
    {
        /*Player2Count.text = "Carrying: " + playerTwoCount.ToString();*/
        //Et loop der tjekker for coins. hvergang man samler en coin op aktiverer den coin sprite og mister man eller ikke har nogle er der en empty coin sprite aktiveret.
        for (int i = 0; i < coins.Length; i++)
        {
            if (i < playerTwoCount)
            {
                coins[i].sprite = fullCoin;
            }
            else
            {
                coins[i].sprite = emptyCoin;
            }

            if (i < maxCoinHeld)
            {
                coins[i].enabled = true;
            }
            else
            {
                coins[i].enabled = false;
            }
        }
    }

    void SetPlayerTwoTotalText()
    {
        Player2Total.text = "Total: " + "<sprite=0>" + playerTwoTotal.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueHome"))
        {

            playerTwoTotal = playerTwoTotal + playerTwoCurrentCount;

            playerTwoCount = 0;
            playerTwoCurrentCount = 0;

            SetPlayerTwoCountText();
            SetPlayerTwoTotalText();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (playerTwoCount <= 2)
            {
                Destroy(other.gameObject);
                playerTwoCount = playerTwoCount + 1;
                playerTwoCurrentCount = playerTwoCount;

                SetPlayerTwoCountText();
            }

            if (playerTwoCount == 3)
            {
                other.gameObject.GetComponent<SphereCollider>().enabled = false;

                other.gameObject.GetComponent<SphereCollider>().enabled = true;
            }
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            playerTwoCount = 0;
            playerTwoCurrentCount = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
