using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class WalkingSound2 : MonoBehaviour
{
    public bool soundPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var moveUp2 = Input.GetKey("w");
        var moveDown2 = Input.GetKey("s");
        var moveLeft2 = Input.GetKey("d");
        var moveRight2 = Input.GetKey("a");


        if (moveUp2 || moveDown2 || moveLeft2 || moveRight2)
        {

            if (!soundPlaying)
            {
                FindObjectOfType<AudioManager>().Play("Walk2");
            }

        }


        else
        {
            FindObjectOfType<AudioManager>().Stop("Walk2");
        }
    }
}
