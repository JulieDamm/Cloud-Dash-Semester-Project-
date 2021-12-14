using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutPlayer1Skills : MonoBehaviour
{
    private Rigidbody rb;
    private SpriteRenderer sr;
    private CapsuleCollider cc;

    public float DashSpeed = 25;

    public float PushSpeed = 40;

    public float BlinkSpeed = 45;

    public float CoolDownTime = 5;

    public float NextFireTime = 0;

    public int RandomSkill1;
    public int OriSkill1;

    public Vector3 Jump;

    public float JumpForce = 10;

    public Control C;

    public GameObject DashReady1;
    public GameObject DashDown1;
    public GameObject PushReady1;
    public GameObject PushDown1;
    public GameObject JumpReady1;
    public GameObject JumpDown1;
    public GameObject TeleportReady1;
    public GameObject TeleportDown1;

    // 1 = Dash 2 = Push 3 = Jump 4 = Teleport


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CapsuleCollider>();


        RandomSkill1 = Random.Range(1, 5);
        OriSkill1 = RandomSkill1;

        DashSpeed = 30;
        PushSpeed = 40;
        BlinkSpeed = 25;
        JumpForce = 25;

        if (RandomSkill1 == 2)
        {
            rb.mass = 1.5f;
        }
        DashReady1.SetActive(false);
        PushReady1.SetActive(false);
        JumpReady1.SetActive(false);
        TeleportReady1.SetActive(false);
        DashDown1.SetActive(false);
        PushDown1.SetActive(false);
        JumpDown1.SetActive(false);
        TeleportDown1.SetActive(false);

        if (RandomSkill1 == 1)
        {
            DashReady1.SetActive(true);
        }
        if (RandomSkill1 == 2)
        {
            PushReady1.SetActive(true);
        }
        if (RandomSkill1 == 3)
        {
            JumpReady1.SetActive(true);
        }
        if (RandomSkill1 == 4)
        {
            TeleportReady1.SetActive(true);
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
            C.speed = 1;
            rb.drag = 5;
            if (Time.time > NextFireTime)
            {
                if (Input.GetKey("l"))
                {
                    rb.AddForce(movement * DashSpeed, ForceMode.Impulse);
                    
                    DashReady1.SetActive(false);
                    DashDown1.SetActive(true);
                    StartCoroutine(CD1());
                    NextFireTime = Time.time + CoolDownTime;

                }
            }
        }
        if (RandomSkill1 == 2)
        {
            C.speed = 1.3f;
            rb.drag = 5;

            if (Time.time > NextFireTime)
            {
                if (Input.GetKey("l"))
                {
                    rb.AddForce(movement * PushSpeed, ForceMode.Impulse);
                    
                    PushReady1.SetActive(false);
                    PushDown1.SetActive(true);
                    StartCoroutine(CD1());
                    NextFireTime = Time.time + CoolDownTime;
                    rb.mass = 50;
                    StartCoroutine(Push1());
                }
            }
        }
        if (RandomSkill1 == 3)
        {
            C.speed = 0.9f;
            rb.mass = 1;
            rb.drag = 5;
            Jump = new Vector3(0.0f, 1f, 0.0f);

            if (Time.time > NextFireTime)
            {
                if (Input.GetKey("l"))
                {
                    rb.AddForce(Jump * JumpForce, ForceMode.VelocityChange);
                    
                    JumpReady1.SetActive(false);
                    JumpDown1.SetActive(true);
                    StartCoroutine(CD1());
                    NextFireTime = Time.time + CoolDownTime;
                }
            }
        }
        if (RandomSkill1 == 4)
        {
            C.speed = 0.9f;
            rb.mass = 1;
            rb.drag = 5;

            if (Time.time > NextFireTime)
            {
                if (Input.GetKey("l"))

                {
                    C.speed = 0;
                    
                    sr.enabled = false;
                    cc.enabled = false;
                    TeleportReady1.SetActive(false);
                    TeleportDown1.SetActive(true);
                    StartCoroutine(CD1());
                    rb.AddForce(movement * BlinkSpeed, ForceMode.Impulse);
                    //rb.transform.Translate(movement * BlinkSpeed);
                    NextFireTime = Time.time + CoolDownTime;
                    StartCoroutine(Blink1());
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

    IEnumerator Blink1()
    {
        yield return new WaitForSeconds(0.3f);
        sr.enabled = true;
        cc.enabled = true;

        C.speed = 0.9f;
    }

    IEnumerator CD1()
    {
        yield return new WaitForSeconds(5);
        if (RandomSkill1 == 1)
        {
            DashReady1.SetActive(true);
            DashDown1.SetActive(false);
        }
        if (RandomSkill1 == 2)
        {
            PushReady1.SetActive(true);
            PushDown1.SetActive(false);
        }
        if (RandomSkill1 == 3)
        {
            JumpReady1.SetActive(true);
            JumpDown1.SetActive(false);
        }
        if (RandomSkill1 == 4)
        {
            TeleportReady1.SetActive(true);
            TeleportDown1.SetActive(false);
        }
    }

}
