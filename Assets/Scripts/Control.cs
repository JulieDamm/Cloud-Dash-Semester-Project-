using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    public bool moving;
    //public bool SpeedBoost;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //InvokeRepeating("CheckDrag", 0.1f, 0.2f);
    }

   
    
    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (gameObject.CompareTag("Player1"))
        {
           /* if (Input.GetKeyDown("space"))
            if (speed == 10)
            {
                speed = 15;
            }
            else
                {
                    speed = 10;
                }
           */


            float moveHorizontal = Input.GetAxis("Horizontal1");
            //float Jump = Input.GetAxis("Jump");
            float moveVertical = Input.GetAxis("Vertical1");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


            //rb.transform.Translate(movement * speed);  //God Speed = 0.05
            rb.AddForce(movement * speed, ForceMode.Impulse); //God Speed = 10
            //rb.velocity = movement * speed;
            

        }


        else
        {
           
            /*if (Input.GetKeyDown("f"))
            if (rb.mass == 1)
            {
                    rb.mass = 10;
            }
            else
                {
                    rb.mass = 1;
                }
            */
            
            float moveHorizontal = Input.GetAxis("Horizontal2");
            float moveVertical = Input.GetAxis("Vertical2");        
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            
            //rb.transform.Translate(movement * speed);  //God Speed = 0.05
            rb.AddForce(movement * speed, ForceMode.Impulse); //God Speed = 10
            //rb.velocity = (movement * speed);
          
        }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //rb.drag = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUP"))
        {
            other.gameObject.SetActive(false);
        }
        // Indtil videre er der ingen reel PowerUP
        Debug.Log("TORNADO");

    }
}
