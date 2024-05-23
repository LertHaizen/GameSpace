using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : Unit
{
    public override void Cry()
    {
        Debug.Log("Жду приказаний!");
        Debug.Log("Скорость" + Speed + "Урон" + Damage);
    }
}
