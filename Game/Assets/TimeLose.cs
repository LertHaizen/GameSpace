using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLose : MonoBehaviour
{
    public static int rob_hous = 0;
    private float TreeTime; 
    private void Update()
    {
        TreeTime = Resurs.tree;
        Resurs.tree = TreeTime - Time.deltaTime * rob_hous;
        rob_hous = 1 + 3 * ShopBuilding.win_build + factory.win_robot;
        
    }
}
