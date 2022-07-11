using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject mathelp;
    void Start()
    {
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pausegame()
    {
        pausemenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resumegame()
    {
        pausemenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void help()
    {
        mathelp.gameObject.SetActive(true);
    }
    public void closehelp()
    {
        mathelp.gameObject.SetActive(false);
    }
}
