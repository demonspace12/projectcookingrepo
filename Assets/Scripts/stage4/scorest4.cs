using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scorest4 : MonoBehaviour
{
    public GameObject[] starstage;
    public Sprite starfill;
    public int currentstar;
    public stage4 timerSC3;
    void Start()
    {

    }


    void Update()
    {
        updatecurreantstar();
        updateUistar();
    }
    public void updatecurreantstar()
    {
        if (timerSC3.coin > 360)
        {
            currentstar = 3;
        }
        else if (timerSC3.coin > 260 && timerSC3.coin <= 360)
        {
            currentstar = 2;
        }
        else if (timerSC3.coin > 160 && timerSC3.coin <= 260)
        {
            currentstar = 1;
        }
    }
    public void updateUistar()
    {
        for (int i = 0; i < currentstar; i++)
        {
            starstage[i].gameObject.GetComponent<Image>().sprite = starfill;
        }
    }
    public void clickBTN(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
