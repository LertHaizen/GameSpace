using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Lives = 5;
    public static int winEnemy = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
            Lives -= 1;
            Destroy(collision.gameObject);
            if (Lives <= 0)
            {
                Destroy(gameObject);
                winEnemy -= 1;
            }
        }
    }
    private void Update()
    {

    }
}
