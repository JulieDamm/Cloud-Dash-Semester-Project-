using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTornadoBehaviour : MonoBehaviour
{
    public float speed = 1;
    public GameObject BlueTornadoClone;
    //public PlayerOneCollectables playerOne;
    //public PlayerTwoCollectables playerTwo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyTornado());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    IEnumerator DestroyTornado()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
