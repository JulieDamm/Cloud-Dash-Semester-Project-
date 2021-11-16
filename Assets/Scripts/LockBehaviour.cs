using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBehaviour : MonoBehaviour
{
    public GameObject LockClone;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Unlock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Unlock()
    {
        yield return new WaitForSeconds(5f);
        Destroy(LockClone);
    }
}
