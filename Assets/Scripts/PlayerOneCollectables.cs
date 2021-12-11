using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerOneCollectables : MonoBehaviour
{
    public TextMeshProUGUI Player1Count;
    public TextMeshProUGUI Player1Total;
    public TextMeshProUGUI Player1WinText;

    public int playerOneCount;
    private int playerOneCurrentCount;
    public int playerOneTotal;
    public bool gameWon;

    public int maxCoinHeld;
    public Image[] coins;
    public Sprite fullCoin;
    public Sprite emptyCoin;
    public Image PlayerOneWinscreen;
    private SpriteRenderer spriteR;

    public Collider CoinCollider;

    public GameObject RedTornado;
    public GameObject RedTornadoClone;
    public Transform[] RedTornadoSpawnPoints;
    public GameObject Lock;
    public GameObject LockClone;
    public Sprite SheepIce;
    public Player2Skills P2S;

    public GameObject SkyBrikker;
    public Animator animator;
    public Sprite WinSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerOneCount = 0;
        playerOneTotal = 0;

        SetPlayerOneCountText();
        SetPlayerOneTotalText();

        gameWon = false;

        PlayerOneWinscreen.enabled = false;
    }

    public void SetPlayerOneCountText()
    {
        /*Player1Count.text = "Carrying: " + playerOneCount.ToString();*/
        //Et loop der tjekker for coins. hvergang man samler en coin op aktiverer den coin sprite og mister man eller ikke har nogle er der en empty coin sprite aktiveret.
        for (int i = 0; i < coins.Length; i++)
        {
            if(i < playerOneCount)
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

    void SetPlayerOneTotalText()
    {
        spriteR = GetComponent<SpriteRenderer>();


        Player1Total.text = "Total: " + "<sprite=0>" + playerOneTotal.ToString();
    }

    void SetPlayerOneWinText()
    {

        //Player1WinText.text = "<color=red>Red Player</color> Wins! <br> <size=24>Press 'R' to Restart</size>";
        Player1WinText.text = "<size=24> Press 'R' to Restart</size>";
        PlayerOneWinscreen.enabled = true;
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
        if (collision.gameObject.CompareTag("RedHome"))
        {
       
          //Spiller lyd naar spiller har coin. SKAL vaere over PlayerTotal Addition
         if (playerOneCurrentCount >= 1)

         {
          FindObjectOfType<AudioManager>().Play("Coindrop");
         }

            playerOneTotal = playerOneTotal + playerOneCurrentCount;

            playerOneCount = 0;
            playerOneCurrentCount = 0;

            SetPlayerOneCountText();
            SetPlayerOneTotalText();

            if (playerOneTotal >= 30)
            {
                StartCoroutine(PlayerOneWin());
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
                FindObjectOfType<AudioManager>().Play("Coin");
                playerOneCount = playerOneCount + 1;
                playerOneCurrentCount = playerOneCount;
                Debug.Log(playerOneCount);

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

        
        if (other.gameObject.CompareTag("TornadoPowerUp"))
        {
            Destroy(other.gameObject);

            int redTornadoSpawnPointIndex = Random.Range(0, RedTornadoSpawnPoints.Length);
            RedTornadoClone = Instantiate(RedTornado, RedTornadoSpawnPoints[redTornadoSpawnPointIndex].position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Tornado");
        }

        if (other.gameObject.CompareTag("LockPowerUp"))
        {
            Destroy(other.gameObject);
            LockClone = Instantiate(Lock, new Vector3(-12.45f, 0.1f, 0f), transform.rotation * Quaternion.Euler (0f, 0f, 0f));
            FindObjectOfType<AudioManager>().Play("Lock");
        }

        if (other.gameObject.CompareTag("IcePowerUp"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("Ice");
            GameObject.Find("Player2").GetComponent<Animator>().enabled = false;
            GameObject.Find("Player2").GetComponent<SpriteRenderer>().sprite = SheepIce;
            P2S.RandomSkill2 = 20;
            StartCoroutine(Defrost());
        }
    }

    IEnumerator Defrost()
    {
        yield return new WaitForSeconds(5f);
        GameObject.Find("Player2").GetComponent<Animator>().enabled = true;
        P2S.RandomSkill2 = P2S.OriSkill2;
    }

    IEnumerator PlayerOneWin()
    {
        FindObjectOfType<AudioManager>().Play("Player1Win");
        GetComponent<Control>().enabled = false;
        GetComponent<Animator>().enabled = false;
        //GameObject.Find("Player2").GetComponent<Animator>().enabled = false;
        GameObject.Find("Player2").GetComponent<Control>().enabled = false;
        gameWon = true;
        GetComponent<SpriteRenderer>().sprite = WinSprite;
        GameObject.Find("Player2").GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(1.5f);
        foreach (Transform child in SkyBrikker.transform)
        {
            Destroy(child.gameObject);
        }
        GameObject Spawn2 = GameObject.Find("Spawn 2");
        Destroy(Spawn2);
        GameObject.Find("Player2").GetComponent<Animator>().SetBool("Kinematic", true);
        yield return new WaitForSeconds(2f);
        GameObject.Find("Player2").GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1.9f);
        GameObject Player2 = GameObject.Find("Player2");
        Destroy(Player2);
        SetPlayerOneWinText();
    }
}
