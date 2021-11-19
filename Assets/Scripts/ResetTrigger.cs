using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{

    Vector3 originalPos;
    private Rigidbody rbp;
    public Material red;
    public Material blue;
    public Material originalmat;

    public Renderer Synlig;
    public float platRes = 1.0f;
    public float platFall = 0.5f;
   
    // Start is called before the first frame update
    void Start()
    {
        // Vi gemmer platformens nuv?rende position ved start af banen.
        originalPos = gameObject.transform.position;

        rbp = GetComponent<Rigidbody>();
        
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
            GetComponent<Renderer>().material = red;
        }
        if (collision.gameObject.tag == "Player2")
        {
            StartCoroutine(Fall());
            GetComponent<Renderer>().material = blue;
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
        rbp.isKinematic = false;
    }

    IEnumerator TornadoFall()
    {
        yield return new WaitForSeconds(0.1f);
        rbp.isKinematic = false;
    }

    //N?r vores platform rammer en collider med tag "Respawn" s? starter Platformres funktionen.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            StartCoroutine(PlatformRes());
        }
    }

    //Funktionen sl?r Mesh fra -> venter sekunder -> s?tter platformens position til dens start position -> sl?r Mesh til igen -> S?tter Rigidbody Kinematic til. 
    IEnumerator PlatformRes()
    {
        Synlig.enabled = false;
        yield return new WaitForSeconds(platRes);
        gameObject.transform.position = originalPos;
        GetComponent<Renderer>().material = originalmat;
        Synlig.enabled = true;
        rbp.isKinematic = true;
    }

}
