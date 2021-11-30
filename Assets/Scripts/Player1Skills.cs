using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Skills : MonoBehaviour
{
    private Rigidbody rb;

    public float DashSpeed = 25;

    public float PushSpeed = 40;

    public float BlinkSpeed = 6;

    public float CoolDownTime = 5;

    public float NextFireTime = 0;

    public int RandomSkill1;
    public int OriSkill1;

    public Vector3 Jump;

    public float JumpForce = 10;

    public Control C;

    // 1 = Dash 2 = Push 3 = Jump 4 = Teleport
       

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        RandomSkill1 = Random.Range(1, 5);
        OriSkill1 = RandomSkill1;

        DashSpeed = 30;
        PushSpeed = 40;
        BlinkSpeed = 6;
        JumpForce = 25;

        if (RandomSkill1 == 2)
        {
            rb.mass = 1.5f;
        }
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
            C.speed = 1.1f;
            rb.drag = 5;
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
            C.speed = 1.5f;
            rb.drag = 5;
 
            if (Time.time > NextFireTime)
            {
                if (Input.GetKey("l"))
                {
                    rb.AddForce(movement * PushSpeed, ForceMode.Impulse);
                    NextFireTime = Time.time + CoolDownTime;
                    rb.mass = 50;
                    StartCoroutine(Push1());
                }
            }
        }
        if (RandomSkill1 == 3)
        {
            C.speed = 1;
            rb.mass = 1;
            rb.drag = 5;
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
            C.speed = 1;
            rb.mass = 1;
            rb.drag = 5;

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
            C.speed = 0.4f;
            rb.mass = 0.5f;
            rb.drag = 1;
            if (OriSkill1 == 2)
            {
                StartCoroutine(Ice1());
            }
        }
    }
    IEnumerator Push1()
    {
        yield return new WaitForSeconds(0.5f);
        rb.mass = 1.5f;

    }

    IEnumerator Ice1()
    {
        yield return new WaitForSeconds(5);
        rb.mass = 1.5f;
    }
}

