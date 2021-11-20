using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setname : MonoBehaviour
{
   
    public string savename;
    
    public Text inputtext;
 
    public void Update()
    {
        
    }

    public void checkname()
    {
        if (inputtext.text != "")
        {
            PlayerPrefs.GetString("Nameplayer");
            setname();
        }
        else
        {
            Debug.Log("please enter name");
        }
    }
    public void setname()
    {
        savename = inputtext.text;
        
        PlayerPrefs.SetInt("Coin",100);
        PlayerPrefs.SetString("Nameplayer", savename);
        SceneManager.LoadScene("Homescene");
      
    }
}
