using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutPlayerOneCollect : MonoBehaviour
{

    public int playerOneCount;
    public TextMeshProUGUI Player1Count;
    public TextMeshProUGUI Player1Total;
    private int playerOneCurrentCount;
    public int playerOneTotal;

    public int maxCoinHeld;
    public Sprite fullCoin;
    public Sprite emptyCoin;
    public Image[] coins;

    private SpriteRenderer spriteR;

    public GameObject RedTornado;
    public GameObject RedTornadoClone;
    public Transform[] RedTornadoSpawnPoints;
    public GameObject Lock;
    public GameObject LockClone;
    public Sprite SheepIce;
    public TutPlayer2Skills P2S;
    // Start is called before the first frame update
    void Start()
    {
        playerOneCount = 0;
        playerOneTotal = 0;

        SetPlayerOneCountText();
        SetPlayerOneTotalText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetPlayerOneTotalText()
    {
        spriteR = GetComponent<SpriteRenderer>();


        Player1Total.text = "Total: " + "<sprite=0>" + playerOneTotal.ToString();
    }

    public void SetPlayerOneCountText()
    {
        /*Player1Count.text = "Carrying: " + playerOneCount.ToString();*/
        //Et loop der tjekker for coins. hvergang man samler en coin op aktiverer den coin sprite og mister man eller ikke har nogle er der en empty coin sprite aktiveret.
        for (int i = 0; i < coins.Length; i++)
        {
            if (i < playerOneCount)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedHome"))
        {
            playerOneTotal = playerOneTotal + playerOneCurrentCount;

            playerOneCount = 0;
            playerOneCurrentCount = 0;

            SetPlayerOneCountText();
            SetPlayerOneTotalText();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (playerOneCount <= 2)
            {
                Destroy(other.gameObject);
                playerOneCount = playerOneCount + 1;
                playerOneCurrentCount = playerOneCount;

                SetPlayerOneCountText();
            }
            if (playerOneCount == 3)
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
            
        }
        if (other.gameObject.CompareTag("LockPowerUp"))
        {
            Destroy(other.gameObject);
            LockClone = Instantiate(Lock, new Vector3(-10f, 0.1f, 0f), transform.rotation * Quaternion.Euler(0f, 0f, 0f));
            
        }
        if (other.gameObject.CompareTag("IcePowerUp"))
        {
            Destroy(other.gameObject);
            
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
}
