using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveResurs : MonoBehaviour
{
    public int Lives = 5;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            Lives -= 1;
            Destroy(collision.gameObject);
            if (Lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
