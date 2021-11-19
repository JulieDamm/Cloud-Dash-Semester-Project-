using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Skills : MonoBehaviour
{
    private Rigidbody rb;

    public float DashSpeed = 25;

    public float PushSpeed = 50;

    public float BlinkSpeed = 7;

    public float CoolDownTime = 5;

    public float NextFireTime = 0;

    public int RandomSkill1;

    public Vector3 Jump;

    public float JumpForce = 10;

    public Control C;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        RandomSkill1 = Random.Range(1, 5);

        DashSpeed = 25;
        PushSpeed = 50;
        BlinkSpeed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float Jump = Input.GetAxis("Jump");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (RandomSkill1 == 1)
        {
            rb.mass = 1;
            C.speed = 0.7f;
            if (Time.time > NextFireTime)
            {
                if (Input.GetKey("l"))
                {
                    rb.AddForce(movement * DashSpeed, ForceMode.Impulse);

                    NextFireTime = Time.time + CoolDownTime;
                }
            }
        }
        if (RandomSkill1 == 2)
        {
            rb.mass = 5;
            C.speed = 3;
            if (Time.time > NextFireTime)
            {
                if (Input.GetKey("l"))
                {
                    rb.AddForce(movement * PushSpeed, ForceMode.Impulse);
                    NextFireTime = Time.time + CoolDownTime;

                }
            }
        }
        if (RandomSkill1 == 3)
        {
            C.speed = 0.6f;
            rb.mass = 1;

            Jump = new Vector3(0.0f, 1f, 0.0f);

            if (Time.time > NextFireTime)
            {
                if (Input.GetKey("l"))
                {
                    rb.AddForce(Jump * JumpForce, ForceMode.VelocityChange);
                    NextFireTime = Time.time + CoolDownTime;
                }
            }
        }
        if (RandomSkill1 == 4)
        {
            C.speed = 0.6f;
            rb.mass = 1;
            if (Time.time > NextFireTime)
            {
                if (Input.GetKey("l"))
                {
                    rb.transform.Translate(movement * BlinkSpeed);
                    NextFireTime = Time.time + CoolDownTime;
                }
            }
        }
        if (RandomSkill1 == 20)
        {
            C.speed = 0.2f;
            rb.mass = 0.5f;
            rb.drag = 1;

        }
    }

}
