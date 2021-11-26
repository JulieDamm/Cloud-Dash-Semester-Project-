using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTornadoBehaviour : MonoBehaviour
{
    public float speed = 1;
    public GameObject RedTornadoClone;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyTornado());
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler (90f, 0f, 0f));
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    IEnumerator DestroyTornado()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
