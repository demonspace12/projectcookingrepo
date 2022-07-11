using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setname : MonoBehaviour
{
   
    public string savename;
    public Shopitem[] shopitemspref;
    public Propkitchen[] propitempref;

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
        for(int i = 0; i < shopitemspref.Length; i++)
        {
            PlayerPrefs.SetInt(shopitemspref[i].title,0);
            Debug.Log(PlayerPrefs.GetInt(shopitemspref[i].title));
        }
        for (int i = 0; i < propitempref.Length; i++)
        {
            PlayerPrefs.SetInt(propitempref[i].Propsname, 1);
            Debug.Log(PlayerPrefs.GetInt(propitempref[i].Propsname));
        }


        savename = inputtext.text;
        PlayerPrefs.SetInt("Coin",500);
        PlayerPrefs.SetString("Nameplayer", savename);
        SceneManager.LoadScene("Homescene");
      
    }
}
