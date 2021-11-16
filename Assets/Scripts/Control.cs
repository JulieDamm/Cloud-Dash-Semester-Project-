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

    public float pushspeed;

    public float CooldownTime = 5;

    public float NextFireTime = 0;

    public int RandomSkill = 0;

    public Vector3 Jump;

    public float JumpForce = 2;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerOriPos = gameObject.transform.position;

        Random.Range(1, 3);

        RandomSkill = Random.Range(1, 3);

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


            if (RandomSkill == 1)
            {
                rb.mass = 1;
                speed = 0.7f;
                if (Time.time > NextFireTime)
                {
                    if (Input.GetKey("l"))
                    {
                        rb.AddForce(movement * dashspeed, ForceMode.Impulse);
                        NextFireTime = Time.time + CooldownTime;

                    }
                }
            }

            if (RandomSkill == 2)
            {
                // speed = 0.6 x mass
                rb.mass = 5;
                speed = 3;
                if (Time.time > NextFireTime)
                {
                    if (Input.GetKey("l"))
                    {
                        rb.AddForce(movement * pushspeed, ForceMode.Impulse);
                        NextFireTime = Time.time + CooldownTime;

                    }
                }
            }

            if (RandomSkill == 3)
            {
                speed = 0.6f;
                rb.mass = 1;

                Jump = new Vector3(0.0f, 1f, 0.0f);

                if (Time.time > NextFireTime)
                {
                    if (Input.GetKey("l"))
                    {
                        rb.AddForce(Jump * JumpForce, ForceMode.Impulse);
                        NextFireTime = Time.time + CooldownTime;
                    }
                }
            }
        }


        else
        {

            float moveHorizontal = Input.GetAxis("Horizontal2");
            float moveVertical = Input.GetAxis("Vertical2");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


            rb.AddForce(movement * speed, ForceMode.Impulse);

            if (RandomSkill == 1)
            {
                rb.mass = 1;
                speed = 0.7f;
                if (Time.time > NextFireTime)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        rb.AddForce(movement * dashspeed, ForceMode.Impulse);
                        NextFireTime = Time.time + CooldownTime;

                    }
                }
            }

            if (RandomSkill == 2)
            {
                // speed = 0.6 x mass
                rb.mass = 5;
                speed = 3;
                if (Time.time > NextFireTime)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        rb.AddForce(movement * pushspeed, ForceMode.Impulse);
                        NextFireTime = Time.time + CooldownTime;

                    }
                }
            }

            if (RandomSkill == 3)
            {
                speed = 0.6f;
                rb.mass = 1;

                Jump = new Vector3(0.0f, 1f, 0.0f);

                if (Time.time > NextFireTime)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        rb.AddForce(Jump * JumpForce, ForceMode.Impulse);
                        NextFireTime = Time.time + CooldownTime;
                    }
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
    }

}