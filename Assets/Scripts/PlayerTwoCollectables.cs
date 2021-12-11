using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTwoCollectables : MonoBehaviour
{
    public TextMeshProUGUI Player2Count;
    public TextMeshProUGUI Player2Total;
    public TextMeshProUGUI Player2WinText;

    public int playerTwoCount;
    private int playerTwoCurrentCount;
    public int playerTwoTotal;
    public bool gameWon;

    public int maxCoinHeld;
    public Image[] coins;
    public Sprite fullCoin;
    public Sprite emptyCoin;
    public Image PlayerTwoWinscreen;

    public Collider CoinCollider;

    public GameObject BlueTornado;
    public GameObject BlueTornadoClone;
    public Transform[] BlueTornadoSpawnPoints;
    public GameObject Lock;
    public GameObject LockClone;
    public Sprite MarshmallowIce;
    public Player1Skills P1S;

    public GameObject SkyBrikker;
    public Animator animator;
    public Sprite WinSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerTwoCount = 0;
        playerTwoTotal = 0;

        SetPlayerTwoCountText();
        SetPlayerTwoTotalText();

        gameWon = false;

        PlayerTwoWinscreen.enabled = false;
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

    void SetPlayerTwoWinText()
    {
        //Player2WinText.text = "<color=red>Blue Player</color> Wins! <br> <size=24>Press 'R' to Restart</size>";
        Player2WinText.text = "<size=24> Press 'R' to Restart</size>";
        PlayerTwoWinscreen.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameWon == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BlueHome"))
        {
            //SKAL vare foer totalcount
            if (playerTwoCurrentCount >= 1)
            {
                FindObjectOfType<AudioManager>().Play("Coindrop");
            }

            playerTwoTotal = playerTwoTotal + playerTwoCurrentCount;

            playerTwoCount = 0;
            playerTwoCurrentCount = 0;

            SetPlayerTwoCountText();
            SetPlayerTwoTotalText();

            if (playerTwoTotal >= 30)
            {
                StartCoroutine(PlayerTwoWin());
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
                FindObjectOfType<AudioManager>().Play("Coin");
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
            BlueTornadoClone = Instantiate(BlueTornado, BlueTornadoSpawnPoints[blueTornadoSpawnPointIndex].position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
            FindObjectOfType<AudioManager>().Play("Tornado");
        }

        if (other.gameObject.CompareTag("LockPowerUp"))
        {
            Destroy(other.gameObject);
            LockClone = Instantiate(Lock, new Vector3(12.5f, 0.1f, 0f), transform.rotation * Quaternion.Euler(90f, 0f, 0f));
            FindObjectOfType<AudioManager>().Play("Lock");
        }

        if (other.gameObject.CompareTag("IcePowerUp"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Ice");
            GameObject.Find("Player1").GetComponent<Animator>().enabled = false;
            GameObject.Find("Player1").GetComponent<SpriteRenderer>().sprite = MarshmallowIce;
            P1S.RandomSkill1 = 20;
            StartCoroutine(Defrost());
        }
    }

    IEnumerator Defrost()
    {
        yield return new WaitForSeconds(5f);
        GameObject.Find("Player1").GetComponent<Animator>().enabled = true;
        P1S.RandomSkill1 = P1S.OriSkill1;
    }

    IEnumerator PlayerTwoWin()
    {
        FindObjectOfType<AudioManager>().Play("Player2Win");
        GetComponent<Control>().enabled = false;
        GetComponent<Animator>().enabled = false;
        //GameObject.Find("Player1").GetComponent<Animator>().enabled = false;
        GameObject.Find("Player1").GetComponent<Control>().enabled = false;
        gameWon = true;
        GetComponent<SpriteRenderer>().sprite = WinSprite;
        GameObject.Find("Player1").GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(1.5f);
        foreach (Transform child in SkyBrikker.transform)
        {
            Destroy(child.gameObject);
        }
        GameObject Spawn1 = GameObject.Find("Spawn 1");
        Destroy(Spawn1);
        GameObject.Find("Player1").GetComponent<Animator>().SetBool("Kinematic", true);
        yield return new WaitForSeconds(2f);
        GameObject.Find("Player1").GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1.9f);
        GameObject Player1 = GameObject.Find("Player1");
        Destroy(Player1);
        SetPlayerTwoWinText();
    }
}