using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject Win_Panel;
    public GameObject Panel;
    private void Update()
    {
        
        int winB = ShopBuilding.win_build;
        int winR = factory.win_robot;
        int winE = EnemySpawn.waveEnemis;
        Debug.Log(winE);
        if (winB >= 4 && winR >= 6 && winE == 0)
        {
            Time.timeScale = 0f;
            Win_Panel.SetActive(true);
            Panel.SetActive(false);
            winB = 0;
            winR = 0;
            ShopBuilding.win_build = 0;
            factory.win_robot = 0;
            Enemy.winEnemy = 0;
            GameObject TimeScript = GameObject.Find("Player");
            Shooting Script = TimeScript.GetComponent<Shooting>();
            Script.enabled = false;
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Win_continue()
    {
        Win_Panel.SetActive(false);
        Panel.SetActive(true);
        GameObject TimeScript = GameObject.Find("Player");
        Shooting Script = TimeScript.GetComponent<Shooting>();
        Script.enabled = true;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }
    public void To_Menu()
    {
        ShopBuilding.win_build = 0;
        factory.win_robot = 0;
        SceneManager.LoadScene(0);
        
    }
}
