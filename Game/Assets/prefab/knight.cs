using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : Unit
{
    public override void Cry()
    {
        Debug.Log("��� ����������!");
        Debug.Log("��������" + Speed + "����" + Damage);
    }
}
