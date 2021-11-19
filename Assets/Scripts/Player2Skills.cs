using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Skills : MonoBehaviour
{
    private Rigidbody rb;

    public float DashSpeed = 25;

    public float PushSpeed = 50;

    public float BlinkSpeed = 7;

    public float CoolDownTime = 5;

    public float NextFireTime = 0;

    public int RandomSkill2;

    public Vector3 Jump;

    public float JumpForce = 10;

    public Control C;

    public Player1Skills P1S;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        RandomSkill2 = Random.Range(1, 5);

        DashSpeed = 25;
        PushSpeed = 50;
        BlinkSpeed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (P1S.RandomSkill1 == RandomSkill2)
        {
            RandomSkill2 = Random.Range(1, 5);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal2");
        //float Jump = Input.GetAxis("Jump");
        float moveVertical = Input.GetAxis("Vertical2");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (RandomSkill2 == 1)
        {
            rb.mass = 1;
            C.speed = 0.7f;
            if (Time.time > NextFireTime)
            { 
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(movement * DashSpeed, ForceMode.Impulse);

                    NextFireTime = Time.time + CoolDownTime;
                }
            }
        }
        if (RandomSkill2 == 2)
        {
            rb.mass = 5;
            C.speed = 3;
            if (Time.time > NextFireTime)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(movement * PushSpeed, ForceMode.Impulse);
                    NextFireTime = Time.time + CoolDownTime;

                }
            }
        }
        if (RandomSkill2 == 3)
        {
            C.speed = 0.6f;
            rb.mass = 1;

            Jump = new Vector3(0.0f, 1f, 0.0f);

            if (Time.time > NextFireTime)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(Jump * JumpForce, ForceMode.VelocityChange);
                    NextFireTime = Time.time + CoolDownTime;
                }
            }
        }
        if (RandomSkill2 == 4)
        {
            C.speed = 0.6f;
            rb.mass = 1;
            if (Time.time > NextFireTime)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.transform.Translate(movement * BlinkSpeed);
                    NextFireTime = Time.time + CoolDownTime;
                }
            }
        }
        if (RandomSkill2 == 20)
        {
            C.speed = 0.2f;
            rb.mass = 0.5f;
            rb.drag = 1;
        }
    }
}
