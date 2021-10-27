using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singlelevel : MonoBehaviour
{
    private int currentstar = 0;
    public int level;
    public void clickback()
    {
        SceneManager.LoadScene("Mapselectscene");
    }
    public void clickstar(int numstar)
    {
        currentstar = numstar;
        if (currentstar > PlayerPrefs.GetInt("lv" + level))
        {
            Debug.Log(PlayerPrefs.GetInt("lv" + level));
            PlayerPrefs.SetInt("lv" + level,currentstar);
        }
        Debug.Log(PlayerPrefs.GetInt("lv" + level));
    }
}
