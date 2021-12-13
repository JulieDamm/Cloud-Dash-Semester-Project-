using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{

    Vector3 originalPos;
    private Rigidbody rbp;
    public Material originalmat;

    public Renderer Synlig;
    private SpriteRenderer spriteRenderer;
    private BoxCollider cloudCollider;
    public Sprite blueCloud;
    public Sprite redCloud;
    public Sprite whiteCloud;
    public float platRes = 1.0f;
    public float platFall = 0.5f;

    public ParticleSystem CloudBurst;
    public PlayerOneCollectables pO;
   
    // Start is called before the first frame update
    void Start()
    {
        // Vi gemmer platformens nuv?rende position ved start af banen.
        originalPos = gameObject.transform.position;

        rbp = GetComponent<Rigidbody>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        cloudCollider = gameObject.GetComponent<BoxCollider>();

        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //N?r en "Player" rammer objektet starter Fall funktionen
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            StartCoroutine(Fall());
            GetComponent<SpriteRenderer>().sprite = redCloud;
        }
        if (collision.gameObject.tag == "Player2")
        {
            StartCoroutine(Fall());
            GetComponent<SpriteRenderer>().sprite = blueCloud;
        }

        if (collision.gameObject.tag == "Tornado")
        {
            StartCoroutine(TornadoFall());
        }
    }

    //Fall afventer i sekunder og derefter sl?r kinematik fra. 
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(platFall);
        transform.GetChild(0).gameObject.SetActive(true);
        cloudCollider.enabled = false;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.3f);
        transform.GetChild(0).gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Puff");
        //Synlig.enabled = false;
        yield return new WaitForSeconds(platRes);
        //gameObject.transform.position = originalPos;
        //Synlig.enabled = true;
        //rbp.isKinematic = true;
        cloudCollider.enabled = true;
        GetComponent<SpriteRenderer>().sprite = whiteCloud;
        spriteRenderer.enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Puff");
        yield return new WaitForSeconds(2f);
        transform.GetChild(0).gameObject.SetActive(false);
    }

    IEnumerator TornadoFall()
    {
        yield return new WaitForSeconds(0.1f);
        //rbp.isKinematic = false;
        cloudCollider.enabled = false;
        spriteRenderer.enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(platRes);
        transform.GetChild(0).gameObject.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = whiteCloud;
        cloudCollider.enabled = true;
        spriteRenderer.enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        transform.GetChild(0).gameObject.SetActive(false);
    }

    

    //N?r vores platform rammer en collider med tag "Respawn" s? starter Platformres funktionen.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            //StartCoroutine(PlatformRes());
        }
    }

    //Funktionen sl?r Mesh fra -> venter sekunder -> s?tter platformens position til dens start position -> sl?r Mesh til igen -> S?tter Rigidbody Kinematic til. 
    //IEnumerator PlatformRes()
    //{

    //}

    IEnumerator PlayerOneWin()
    {
        if (pO.gameWon)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
