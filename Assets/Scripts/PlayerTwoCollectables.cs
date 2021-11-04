using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTwoCollectables : MonoBehaviour
{
    public TextMeshProUGUI Player2Count;
    public TextMeshProUGUI Player2Total;
    public TextMeshProUGUI Player2WinText;

    public int playerTwoCount;
    private int playerTwoCurrentCount;
    public int playerTwoTotal;
    public bool gameWon;

    public Collider CoinCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerTwoCount = 0;
        playerTwoTotal = 0;

        SetPlayerTwoCountText();
        SetPlayerTwoTotalText();

        gameWon = false;
    }

    void SetPlayerTwoCountText()
    {
        Player2Count.text = "Carrying: " + playerTwoCount.ToString();
    }

    void SetPlayerTwoTotalText()
    {
        Player2Total.text = "Total: " + playerTwoTotal.ToString();
    }

    void SetPlayerTwoWinText()
    {
        Player2WinText.text = "Player 2 Wins!";
    }

    // Update is called once per frame
    void Update()
    {

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

            if (playerTwoTotal >= 10)
            {
                SetPlayerTwoWinText();
                GetComponent<Control>().enabled = false;
                GameObject.Find("Player1").GetComponent<Control>().enabled = false;
                gameWon = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (playerTwoCount <= 4)
            {
                Destroy(other.gameObject);
                playerTwoCount = playerTwoCount + 1;
                playerTwoCurrentCount = playerTwoCount;

                SetPlayerTwoCountText();
            }

            if (playerTwoCount == 5)
            {
                other.gameObject.GetComponent<SphereCollider>().enabled = false;

                other.gameObject.GetComponent<SphereCollider>().enabled = true;
            }
        }
    }
}