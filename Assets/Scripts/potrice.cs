using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potrice : MonoBehaviour
{
    public SpriteRenderer potricemain;
    public timer timerSC2;
    public bool potriceready = false;
    public int potricetime = 7;
    public Sprite potricecook;
    public Sprite potricenormal;

    public GameObject[] rice;
    public int riceselect;
    public bool clickbagrice = false;
    public Propkitchen proppotrice;
    public Shopitem itemrice;
    
    void Start()
    {
        potricetime = 7 - PlayerPrefs.GetInt(proppotrice.Propsname);
        for (int i = 0; i < rice.Length; i++)
        {
            rice[i].gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickpotrice()
    {
        if (clickbagrice == true )
        {

            potriceready = true;
            potricemain.GetComponent<SpriteRenderer>().sprite = potricecook;
            PlayerPrefs.SetInt(itemrice.title, PlayerPrefs.GetInt(itemrice.title) - 1);
            Debug.Log(PlayerPrefs.GetInt(itemrice.title));
            clickbagrice = false;


        }
    }
    public void clickrice(int numrice)
    {
        riceselect = numrice;
        Debug.Log(riceselect);
    }
    public void bagrice()
    {
        clickbagrice = true;
        
    }
}
