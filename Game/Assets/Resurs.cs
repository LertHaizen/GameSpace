using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Resurs : MonoBehaviour
{
    public static int metal = 100;
    public static float tree = 1000;
    public static int stone = 1000;
    public static int material = 100000;
    public static int win_build = 0;
    public TMPro.TMP_Text tree_text;
    public TMPro.TMP_Text material_text;
    public TMPro.TMP_Text stone_text;
    public TMPro.TMP_Text metal_text;
    private ShopBuilding shopBuilding;
    bool Panel = false;
    public GameObject Build_Panel;
    public GameObject Resurs_Panel;
    public static int rob_hous;

    public void OnClick1()
    {
            material += stone * 8 / 2;
            stone = 0;    
    }
    public void OnClick2()
    {
            material += (metal * metal) / 2;
            metal = 0;
    }
    private void Start()
    {
        shopBuilding = GetComponent<ShopBuilding>();
    }
    private void OnTriggerStay(Collider other)
    {
       
       if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            Resurs_Panel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject TimeScriptS = GameObject.Find("Player");
            Shooting ScriptS = TimeScriptS.GetComponent<Shooting>();
            ScriptS.enabled = false;
            FirstPersonController ScriptF = TimeScriptS.GetComponent<FirstPersonController>();
            ScriptF.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Resurs_Panel.SetActive(false);
            Cursor.visible = false;
            GameObject TimeScriptS = GameObject.Find("Player");
            Shooting ScriptS = TimeScriptS.GetComponent<Shooting>();
            FirstPersonController ScriptF = TimeScriptS.GetComponent<FirstPersonController>();
            ScriptF.enabled = true;
            ScriptS.enabled = true;
        }
    }
    private void Update()
    {
        tree -= Time.deltaTime * rob_hous;
        rob_hous = 3 + ShopBuilding.win_build + factory.win_robot;
        tree_text.text = tree.ToString("F0");
        stone_text.text = stone.ToString();
        metal_text.text = metal.ToString();
        material_text.text = material.ToString();
        int int_tree = (int)tree;
        if (tree < 0)
        {
            tree = 1000;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Resurs_Panel.SetActive(false);
            Cursor.visible = false;
            GameObject TimeScriptS = GameObject.Find("Player");
            Shooting ScriptS = TimeScriptS.GetComponent<Shooting>();
            FirstPersonController ScriptF = TimeScriptS.GetComponent<FirstPersonController>();
            ScriptF.enabled = true;
            ScriptS.enabled = true;
        }

        if (shopBuilding.StatusBuy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shopBuilding.PurchaseBuilding();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                shopBuilding.CancelBuy();
            }
                shopBuilding.MoveHologram();
            
            
        }

        if (Input.GetKeyDown(KeyCode.Z) && Panel == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Build_Panel.SetActive(true);
            GameObject TimeScriptS = GameObject.Find("Player");
            Shooting ScriptS = TimeScriptS.GetComponent<Shooting>();
            ScriptS.enabled = false;
            Panel = true;

        }
        if (Input.GetKeyDown(KeyCode.X) && Panel == true)
        {
            Build_Panel.SetActive(false);
            GameObject TimeScriptS = GameObject.Find("Player");
            Shooting ScriptS = TimeScriptS.GetComponent<Shooting>();
            ScriptS.enabled = true;
            Panel = false;

        }
    }
}
