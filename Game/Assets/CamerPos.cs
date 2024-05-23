using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerPos : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    private void Start()
    {
        Cam1.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Cam2.SetActive(true);
            Cam1.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
        }
    }
}
