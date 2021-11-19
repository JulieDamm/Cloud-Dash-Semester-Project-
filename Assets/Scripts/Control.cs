using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Control : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    Vector3 playerOriPos;

   


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

            float moveHorizontal = Input.GetAxis("Horizontal");
            //float Jump = Input.GetAxis("Jump");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed, ForceMode.Impulse);

        }

        if (gameObject.CompareTag("Player2"))
        {

            float moveHorizontal = Input.GetAxis("Horizontal2");
            float moveVertical = Input.GetAxis("Vertical2");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


            rb.AddForce(movement * speed, ForceMode.Impulse);
        }

            
        }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Respawn")
        {
            gameObject.transform.position = playerOriPos;
        }
    }



}