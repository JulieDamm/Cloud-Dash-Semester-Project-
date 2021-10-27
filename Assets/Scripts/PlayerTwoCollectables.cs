using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTwoCollectables : MonoBehaviour
{
    public TextMeshProUGUI Player2Count;
    public TextMeshProUGUI Player2Total;

    public int playerTwoCount;
    private int playerTwoCurrentCount;
    public int playerTwoTotal;

    public Collider CoinCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerTwoCount = 0;
        playerTwoTotal = 0;

        SetPlayerTwoCountText();
        SetPlayerTwoTotalText();
    }

    void SetPlayerTwoCountText()
    {
        Player2Count.text = "Carrying: " + playerTwoCount.ToString();
    }

    void SetPlayerTwoTotalText()
    {
        Player2Total.text = "Total: " + playerTwoTotal.ToString();
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (playerTwoCount <= 4)
            {
                other.gameObject.SetActive(false);
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