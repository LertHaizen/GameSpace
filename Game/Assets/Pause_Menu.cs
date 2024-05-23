using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Menu : MonoBehaviour
{
    public GameObject Pause_Panel;
    public GameObject Canvas;
    private bool _boolPanel = false;
    public Button button ;
    private int NomberFabric = 0;
    private ShopBuilding shopBuilding;
    bool buttonDownFabric = false;
    bool buttonDownHous = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && buttonDownFabric == true)
        {
            NomberFabric = 1;
        }
        if (Input.GetMouseButtonDown(1) && NomberFabric == 0)
        {
            button.gameObject.SetActive(true);
            buttonDownFabric = false;
        }
        if (Input.GetMouseButtonDown(0) && buttonDownHous == true)
        {
            factory.Limit_robot += 3;
            buttonDownHous = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _boolPanel == false )
        {
            GameObject TimeScript = GameObject.Find("Player");
            Shooting Script = TimeScript.GetComponent<Shooting>();
            Canvas.SetActive(false);
            Script.enabled = false;
            Time.timeScale = 0f;
            Pause_Panel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _boolPanel = true;
            FirstPersonController ScriptF = TimeScript.GetComponent<FirstPersonController>();
            ScriptF.enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _boolPanel == true)
        {
            GameObject TimeScript = GameObject.Find("Player");
            Shooting Script = TimeScript.GetComponent<Shooting>();
            Script.enabled = true;
            Canvas.SetActive(true);
            Time.timeScale = 1f;
            Pause_Panel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            _boolPanel = false;
            FirstPersonController ScriptF = TimeScript.GetComponent<FirstPersonController>();
            ScriptF.enabled = true;
        }
    }

    public void Pause_Off()
    {
        GameObject TimeScript = GameObject.Find("Player");
        Shooting Script = TimeScript.GetComponent<Shooting>();
        Script.enabled = true;
        Canvas.SetActive(true);
        Time.timeScale = 1f;
        Pause_Panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        _boolPanel = false;
        FirstPersonController ScriptF = TimeScript.GetComponent<FirstPersonController>();
        ScriptF.enabled = true;

    }

    public void To_Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        ShopBuilding.win_build = 0;
        factory.win_robot = 0;
    }
    public void Off_Button()
    {
        if (Resurs.material >= 5000)
        { 
           button.gameObject.SetActive(false);
           buttonDownFabric = true;
        }
    }
    public void ButtonRobot()
    {

        buttonDownHous = true;
    }
}
 

