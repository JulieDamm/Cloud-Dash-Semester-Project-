using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Skills : MonoBehaviour
{
    private Rigidbody rb;
    private SpriteRenderer sr;
    private CapsuleCollider cc;

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

    public GameObject DashReady2;
    public GameObject DashDown2;
    public GameObject PushReady2;
    public GameObject PushDown2;
    public GameObject JumpReady2;
    public GameObject JumpDown2;
    public GameObject TeleportReady2;
    public GameObject TeleportDown2;
    // 1 = Dash 2 = Push 3 = Jump 4 = Teleport

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CapsuleCollider>();

        DashReady2.SetActive(false);
        PushReady2.SetActive(false);
        JumpReady2.SetActive(false);
        TeleportReady2.SetActive(false);
        DashDown2.SetActive(false);
        PushDown2.SetActive(false);
        JumpDown2.SetActive(false);
        TeleportDown2.SetActive(false);

        RandomSkill2 = Random.Range(1, 5);
        OriSkill2 = RandomSkill2;

        DashSpeed = 30;
        PushSpeed = 40;
        BlinkSpeed = 25;
        JumpForce = 25;

        if (RandomSkill2 == 2)
        {
            rb.mass = 1.5f;
        }

        if (RandomSkill2 == 1)
        {
            DashReady2.SetActive(true);
        }
        if (RandomSkill2 == 2)
        {
            PushReady2.SetActive(true);
        }
        if (RandomSkill2 == 3)
        {
            JumpReady2.SetActive(true);
        }
        if (RandomSkill2 == 4)
        {
            TeleportReady2.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (P1S.RandomSkill1 == RandomSkill2)
        {
            DashReady2.SetActive(false);
            PushReady2.SetActive(false);
            JumpReady2.SetActive(false);
            TeleportReady2.SetActive(false);
            DashDown2.SetActive(false);
            PushDown2.SetActive(false);
            JumpDown2.SetActive(false);
            TeleportDown2.SetActive(false);
            RandomSkill2 = Random.Range(1, 5);
            OriSkill2 = RandomSkill2;
            

            StartCoroutine(CDTEXT());

            
        }
    }

    IEnumerator CDTEXT()
    {
        yield return new WaitForSeconds(0.1f);
        if (RandomSkill2 == 1)
        {
            DashReady2.SetActive(true);
        }
        if (RandomSkill2 == 2)
        {
            PushReady2.SetActive(true);
        }
        if (RandomSkill2 == 3)
        {
            JumpReady2.SetActive(true);
        }
        if (RandomSkill2 == 4)
        {
            TeleportReady2.SetActive(true);
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
            C.speed = 1;
            rb.drag = 5;
            if (Time.time > NextFireTime)
            { 
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(movement * DashSpeed, ForceMode.Impulse);
                    FindObjectOfType<AudioManager>().Play("Speed");
                    DashReady2.SetActive(false);
                    DashDown2.SetActive(true);
                    StartCoroutine(CD2());
                    NextFireTime = Time.time + CoolDownTime;
                }
            }
        }
        if (RandomSkill2 == 2)
        {
            C.speed = 1.3f;
            rb.drag = 5;

            if (Time.time > NextFireTime)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(movement * PushSpeed, ForceMode.Impulse);
                    FindObjectOfType<AudioManager>().Play("Hit");
                    NextFireTime = Time.time + CoolDownTime;
                    PushReady2.SetActive(false);
                    PushDown2.SetActive(true);
                    StartCoroutine(CD2());
                    rb.mass = 50;
                    StartCoroutine(Push2());
                }
            }
        }
        if (RandomSkill2 == 3)
        {
            C.speed = 0.9f;
            rb.mass = 1;
            rb.drag = 5;
            Jump = new Vector3(0.0f, 1f, 0.0f);

            if (Time.time > NextFireTime)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(Jump * JumpForce, ForceMode.VelocityChange);
                    FindObjectOfType<AudioManager>().Play("Jump");
                    JumpReady2.SetActive(false);
                    JumpDown2.SetActive(true);
                    StartCoroutine(CD2());
                    NextFireTime = Time.time + CoolDownTime;
                }
            }
        }
        if (RandomSkill2 == 4)
        {
            C.speed = 0.9f;
            rb.mass = 1;
            rb.drag = 5;
            if (Time.time > NextFireTime)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    C.speed = 0;
                    FindObjectOfType<AudioManager>().Play("Transport");
                    sr.enabled = false;
                    cc.enabled = false;
                    TeleportReady2.SetActive(false);
                    TeleportDown2.SetActive(true);
                    StartCoroutine(CD2());
                    rb.AddForce(movement * BlinkSpeed, ForceMode.Impulse);
                    //rb.transform.Translate(movement * BlinkSpeed);
                    NextFireTime = Time.time + CoolDownTime;
                    StartCoroutine(Blink2());
                }
            }
            }
        
        if (RandomSkill2 == 20)
        {
            C.speed = 0.4f;
            rb.mass = 0.5f;
            rb.drag = 1;
            if (OriSkill2 == 2)
            {
                StartCoroutine(Ice2());
            }
               
        }
    }

    IEnumerator Push2()
    {
        yield return new WaitForSeconds(0.5f);
        rb.mass = 1.5f;

    }

    IEnumerator Ice2()
    {
        yield return new WaitForSeconds(5);
        rb.mass = 1.5f;
    }
    IEnumerator Blink2()
    {
        yield return new WaitForSeconds(0.3f);
        sr.enabled = true;
        cc.enabled = true;

        C.speed = 0.9f;
    }
    IEnumerator CD2()
    {
        yield return new WaitForSeconds(5);
        if (RandomSkill2 == 1)
        {
            DashReady2.SetActive(true);
            DashDown2.SetActive(false);
        }
        if (RandomSkill2 == 2)
        {
            PushReady2.SetActive(true);
            PushDown2.SetActive(false);
        }
        if (RandomSkill2 == 3)
        {
            JumpReady2.SetActive(true);
            JumpDown2.SetActive(false);
        }
        if (RandomSkill2 == 4)
        {
            TeleportReady2.SetActive(true);
            TeleportDown2.SetActive(false);
        }
    }

}
