using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public TMPro.TMP_Text live_text;
    [SerializeField] private int live = 100;
    bool Un = false;
    void Update()
    {
        live_text.text = live.ToString();
        if (live <= 0)
        {
            live = 100;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
    }
    public void UnSec()
    {
        Un = false;
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Enemy" && Un == false)
        {
            live -= 10;
            Invoke("UnSec", 1f);
            Un = true;
        }
    }
}
