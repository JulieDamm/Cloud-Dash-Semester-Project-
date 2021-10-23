using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{

    Vector3 originalPos;
    private Rigidbody rbp;

    public Renderer Synlig;
    public float platRes = 1.0f;
    public float platFall = 0.5f;
   
    // Start is called before the first frame update
    void Start()
    {
        // Vi gemmer platformens nuværende position ved start af banen.
        originalPos = gameObject.transform.position;

        rbp = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Når en "Player" rammer objektet starter Fall funktionen
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            StartCoroutine(Fall());
        }
        if (collision.gameObject.tag == "Player2")
        {
            StartCoroutine(Fall());
        }
    }

    //Fall afventer i sekunder og derefter slår kinematik fra. 
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(platFall);
        rbp.isKinematic = false;
    }

    //Når vores platform rammer en collider med tag "Respawn" så starter Platformres funktionen.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            StartCoroutine(PlatformRes());
        }
    }

    //Funktionen slår Mesh fra -> venter sekunder -> sætter platformens position til dens start position -> slår Mesh til igen -> Sætter Rigidbody Kinematic til. 
    IEnumerator PlatformRes()
    {
        Synlig.enabled = false;
        yield return new WaitForSeconds(platRes);
        gameObject.transform.position = originalPos;
        Synlig.enabled = true;
        rbp.isKinematic = true;
    }

}
