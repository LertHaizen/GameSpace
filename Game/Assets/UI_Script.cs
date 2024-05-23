using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Help;
    public GameObject history;

    public void To_Continue()
    {
        SceneManager.LoadScene(1);
        Resurs.metal = 100;
        Resurs.tree = 10000;
        Resurs.stone = 100;
        Resurs.material = 1000;
        TimeLose.rob_hous = 1;
}
    public void Exit()
    {
        Application.Quit();
    }
    public void Helps()
    {
        Help.SetActive(true);
        Menu.SetActive(false);
    }
    public void Menus()
    {
        Help.SetActive(false);
        Menu.SetActive(true);
    }
    public void for_History()
    {
        history.SetActive(false);
        Menu.SetActive(true);
    }
    public void InHistory()
    {
        history.SetActive(true);
        Menu.SetActive(false);
    }
}
