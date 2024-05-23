using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class factory : MonoBehaviour
{
    [SerializeField]
    private int _minDamage = 5, _maxDamage = 30;
    [SerializeField]
    private int _minSpeed = 1, _maxSpeed = 10;
    [SerializeField]
    private Transform _spawPoint;
    public static int win_robot = 0;
    public GameObject Spawn_Panel;
    public static int Limit_robot = 0;
    public static int new_robot = 0;
    public TMPro.TMP_Text newRobotText;
    public TMPro.TMP_Text limitText;
    private void Update()
    {
        newRobotText.text = new_robot.ToString();
        limitText.text = Limit_robot.ToString();
        if (Input.GetKeyDown(KeyCode.C))
        {
            Spawn_Panel.SetActive(true);
            GameObject TimeScript = GameObject.Find("Player");
            Shooting Script = TimeScript.GetComponent<Shooting>();
            Script.enabled = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Spawn_Panel.SetActive(false);
            GameObject TimeScript = GameObject.Find("Player");
            Shooting Script = TimeScript.GetComponent<Shooting>();
            Script.enabled = true;
        }
    }
    
    public void Create(Unit unit)
    {
        if (Resurs.material >= 200  && new_robot < Limit_robot)
        {
            Unit instance = Instantiate(unit);
            instance.Initizaleze(Random.Range(_minDamage, _maxDamage),
                           Random.Range(_minSpeed, _maxSpeed));
            new_robot += 1;
            instance.SpawTo(_spawPoint.position);
            instance.Cry();
            Resurs.material -= 400;
            win_robot+=1;
            Debug.Log(win_robot);
        }
    }
}
