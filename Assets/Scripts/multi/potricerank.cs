using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potricerank : MonoBehaviour
{
    public SpriteRenderer potricemain;
    public stagerank timerSC2;
    public bool potriceready = false;
    public int potricetime = 7;
    public Sprite potricecook;
    public Sprite potricenormal;

    public GameObject[] rice;
    public int riceselect;
    public bool clickbagrice = false;
    public Propkitchen proppotrice;
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
        if (clickbagrice == true)
        {

            potriceready = true;
            potricemain.GetComponent<SpriteRenderer>().sprite = potricecook;
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
