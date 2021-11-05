using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Control : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    Vector3 playerOriPos;

    public float dashspeed;

    public float CooldownTime = 5;

    public float NextFireTime = 0;

   


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

    private void FixedUpdate()
    {
        if (gameObject.CompareTag("Player1"))
        {

            float moveHorizontal = Input.GetAxis("Horizontal1");
            //float Jump = Input.GetAxis("Jump");
            float moveVertical = Input.GetAxis("Vertical1");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed, ForceMode.Impulse);

            if (Time.time > NextFireTime)
            {
                if (Input.GetKey("l"))
                {
                    rb.AddForce(movement * dashspeed, ForceMode.Impulse);
                    NextFireTime = Time.time + CooldownTime;

                }
            }
        }


        else
        {

            float moveHorizontal = Input.GetAxis("Horizontal2");
            float moveVertical = Input.GetAxis("Vertical2");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


            rb.AddForce(movement * speed, ForceMode.Impulse);

            if (Time.time > NextFireTime)
            {
                if (Input.GetKey(KeyCode.Space))
                {

                    rb.AddForce(movement * dashspeed, ForceMode.Impulse);
                    NextFireTime = Time.time + CooldownTime;

                }
            }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Respawn")
        {
            gameObject.transform.position = playerOriPos;

         
        }
        /*
        if (other.gameObject.CompareTag("PowerUP"))
        {
            other.gameObject.SetActive(false);
        }
        // Indtil videre er der ingen reel PowerUP
        Debug.Log("TORNADO");

        }*/
    }

}
