using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    
    public bool soundPlaying = false;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var moveUp = Input.GetKey("up");
        var moveDown = Input.GetKey("down");
        var moveLeft = Input.GetKey("left");
        var moveRight = Input.GetKey("right");
        

        if (moveUp || moveDown || moveLeft || moveRight)
        {

            if (!soundPlaying)
            {
                FindObjectOfType<AudioManager>().Play("Walk");
            }

        }

       
        else
        {
            FindObjectOfType<AudioManager>().Stop("Walk");
        }

        
    }
}
