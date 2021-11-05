using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerOneCollectables : MonoBehaviour
{
    public TextMeshProUGUI Player1Count;
    public TextMeshProUGUI Player1Total;
    public TextMeshProUGUI Player1WinText;

    public int playerOneCount;
    public int playerOneCurrentCount;
    public int playerOneTotal;
    public bool gameWon;

    public Collider CoinCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerOneCount = 0;
        playerOneTotal = 0;

        SetPlayerOneCountText();
        SetPlayerOneTotalText();

        gameWon = false;
    }

    public void SetPlayerOneCountText()
    {
        Player1Count.text = "Carrying: " + playerOneCount.ToString();
    }

    void SetPlayerOneTotalText()
    {
        Player1Total.text = "Total: " + playerOneTotal.ToString();
    }

    void SetPlayerOneWinText()
    {
        Player1WinText.text = "Player 1 Wins!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedHome"))
        {
            playerOneTotal = playerOneTotal + playerOneCurrentCount;

            playerOneCount = 0;
            playerOneCurrentCount = 0;

            SetPlayerOneCountText();
            SetPlayerOneTotalText();

            if (playerOneTotal >= 10)
            {
                SetPlayerOneWinText();
                GetComponent<Control>().enabled = false;
                GameObject.Find("Player2").GetComponent<Control>().enabled = false;
                gameWon = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (playerOneCount <= 4)
            {
                Destroy(other.gameObject);
                playerOneCount = playerOneCount + 1;
                playerOneCurrentCount = playerOneCount;

                SetPlayerOneCountText();
            }

            if (playerOneCount == 5)
            {
                other.gameObject.GetComponent<SphereCollider>().enabled = false;

                other.gameObject.GetComponent<SphereCollider>().enabled = true;
            }
        }

        if (other.gameObject.CompareTag("Respawn"))
        {
            playerOneCount = 0;
            playerOneCurrentCount = 0;
        }
    }
}
