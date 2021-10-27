using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{
    SphereCollider CoinCollider;

    // Start is called before the first frame update
    void Start()
    {
        CoinCollider = GetComponent<SphereCollider>();
        CoinCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            CoinCollider.enabled = false;
        }

        if (other.gameObject.CompareTag("Player2"))
        {
            CoinCollider.enabled = false;
        }
    }
}
