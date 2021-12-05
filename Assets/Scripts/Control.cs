using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Control : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    Vector3 playerOriPos;

    public Animator animator;


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

            animator.SetFloat("HorizontalSpeed", Mathf.Abs(moveHorizontal));
            animator.SetFloat("VerticalSpeed", Mathf.Abs(moveVertical));

            if (movement != Vector3.zero)
            {
                transform.forward = movement;
                transform.Rotate(90f, 0f, -90f);
            }

        }

        if (gameObject.CompareTag("Player2"))
        {

            float moveHorizontal = Input.GetAxis("Horizontal2");
            float moveVertical = Input.GetAxis("Vertical2");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


            rb.AddForce(movement * speed, ForceMode.Impulse);

            animator.SetFloat("HorizontalSpeed", Mathf.Abs(moveHorizontal));
            animator.SetFloat("VerticalSpeed", Mathf.Abs(moveVertical));

            if (movement != Vector3.zero)
            {
                transform.forward = movement;
                transform.Rotate(90f, 0f, 90f);
            }
        }

        rb.AddForce(new Vector3(0, -10, 0));
            
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Respawn")
        {
            gameObject.transform.position = playerOriPos;
        }
    }


    

}