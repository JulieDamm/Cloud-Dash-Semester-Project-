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

    public GameObject BlueTornado;
    public GameObject BlueTornadoClone;
    public Transform[] BlueTornadoSpawnPoints;
    public GameObject Lock;
    public GameObject LockClone;
    public Material IceBlue;
    public Material origmat;

    // Start is called before the first frame update
    void Start()
    {
        playerTwoCount = 0;
        playerTwoTotal = 0;

        SetPlayerTwoCountText();
        SetPlayerTwoTotalText();

        gameWon = false;
    }

    public void SetPlayerTwoCountText()
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

        if (other.gameObject.CompareTag("Respawn"))
        {
            playerTwoCount = 0;
            playerTwoCurrentCount = 0;
        }

        if (other.gameObject.CompareTag("TornadoPowerUp"))
        {
            Destroy(other.gameObject);
            int blueTornadoSpawnPointIndex = Random.Range(0, BlueTornadoSpawnPoints.Length);
            BlueTornadoClone = Instantiate(BlueTornado, BlueTornadoSpawnPoints[blueTornadoSpawnPointIndex].position, Quaternion.identity);
        }

        if (other.gameObject.CompareTag("LockPowerUp"))
        {
            Destroy(other.gameObject);
            LockClone = Instantiate(Lock, new Vector3(12.5f, 0.7f, 0f), Quaternion.identity);
        }

        if (other.gameObject.CompareTag("IcePowerUp"))
        {
            Destroy(other.gameObject);
            GameObject.Find("Player1").GetComponent<Renderer>().material = IceBlue;
            StartCoroutine(Defrost());
        }
    }

    IEnumerator Defrost()
    {
        yield return new WaitForSeconds(5f);
        GameObject.Find("Player1").GetComponent<Renderer>().material = origmat;
    }
}