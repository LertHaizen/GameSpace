using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected int Damage;
    protected int Speed;

    public void Initizaleze(int damage, int speed)
    {
        Damage = damage;
        Speed = speed;
    }

    public void SpawTo(Vector3 spawPoint)
    {
        Vector2 randomPoint = Random.insideUnitCircle * 3;
        transform.position = spawPoint + new Vector3(randomPoint.x, 0, randomPoint.y);
    }
    public abstract void Cry();
}
