using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutLock : MonoBehaviour
{

    public GameObject LockClone;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(90f, 0f, 0f));
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
