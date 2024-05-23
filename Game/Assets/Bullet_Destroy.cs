using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Destroy : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy_Bullet", 0.3f);
    }

    private void Destroy_Bullet()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            Resurs.tree += 2000;
        }
        if (collision.gameObject.CompareTag("Metal"))
        {
            Resurs.metal += 15;
        }
        if (collision.gameObject.CompareTag("Stone"))
        {
            Resurs.stone += 75;
        }
    }
}