using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutRespawnTrigger : MonoBehaviour
{
    private Rigidbody rb;

    Vector3 playerOriPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerOriPos = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Respawn")
        {
            
            gameObject.transform.position = playerOriPos;
        }
    }
}
