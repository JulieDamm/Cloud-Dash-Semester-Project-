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

    public int OriSkill2;

    public Vector3 Jump;

    public float JumpForce = 10;

    public Control C;

    public Player1Skills P1S;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        RandomSkill2 = Random.Range(1, 5);
        OriSkill2 = RandomSkill2;

        DashSpeed = 25;
        PushSpeed = 50;
        BlinkSpeed = 7;
        JumpForce = 25;

        if(RandomSkill2 == 2)
        {
            rb.mass = 1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (P1S.RandomSkill1 == RandomSkill2)
        {
            RandomSkill2 = Random.Range(1, 5);
            OriSkill2 = RandomSkill2;
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
            rb.drag = 5;
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
            C.speed = 0.9f;
            rb.drag = 5;
            if (Time.time > NextFireTime)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(movement * PushSpeed, ForceMode.Impulse);
                    NextFireTime = Time.time + CoolDownTime;
                    rb.mass = 50;
                    StartCoroutine(Push2());
                }
            }
        }
        if (RandomSkill2 == 3)
        {
            C.speed = 0.6f;
            rb.mass = 1;
            rb.drag = 5;
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
            rb.drag = 5;
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

    IEnumerator Push2()
    {
        yield return new WaitForSeconds(0.5f);
        rb.mass = 1.5f;

    }

}
