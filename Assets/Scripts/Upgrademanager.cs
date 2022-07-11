using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Upgrademanager : MonoBehaviour
{
    public Propkitchen[] Propitem;
    public GameObject[] PropPanelS;
    public Kitchentemplate[] Proppanel;
    public Sprite level1;
    public Sprite level2;
    public Sprite level3;
    public Sprite level4;
    private int coin;
    public Text textcoin;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Propitem.Length; i++)
        {

            PropPanelS[i].SetActive(true);
            //Debug.Log("1");
        }
        //LoadProp();

    }

    // Update is called once per frame
    void Update()
    {
        coin = PlayerPrefs.GetInt("Coin");
        textcoin.text = coin.ToString();
        LoadProp();
    }
    public void LoadProp()
    {
        for (int i = 0; i < Propitem.Length; i++)
        {
            Proppanel[i].titleprops.text = Propitem[i].Propsname;
            Proppanel[i].iconprop.GetComponent<Image>().sprite = Propitem[i].icon;
            Proppanel[i].costupgrade.text = Propitem[i].upgrade.ToString() + "$";
            if (PlayerPrefs.GetInt(Propitem[i].Propsname) == 1)
            {
                Proppanel[i].proplevel.GetComponent<Image>().sprite = level1;
                

            }
             if (PlayerPrefs.GetInt(Propitem[i].Propsname) == 2)
            {
                Proppanel[i].proplevel.GetComponent<Image>().sprite = level2;
                
            }
            if (PlayerPrefs.GetInt(Propitem[i].Propsname) == 3)
            {
                Proppanel[i].proplevel.GetComponent<Image>().sprite = level3;
               
            }
            if (PlayerPrefs.GetInt(Propitem[i].Propsname) == 4)
            {
                Proppanel[i].proplevel.GetComponent<Image>().sprite = level4;
                
            }
            
        }
        
        

    }
    public void clickupgrade(int propnumber)
    {
       
        if (coin >= Propitem[propnumber].upgrade && PlayerPrefs.GetInt(Propitem[propnumber].Propsname) < 4)
        {
            coin = coin - Propitem[propnumber].upgrade;
            PlayerPrefs.SetInt("Coin", coin);
            textcoin.text = "Coin : " + coin.ToString();
            PlayerPrefs.SetInt(Propitem[propnumber].Propsname, PlayerPrefs.GetInt(Propitem[propnumber].Propsname) + 1);
            Debug.Log(PlayerPrefs.GetInt(Propitem[propnumber].Propsname));

        }
    }
    public void clickback()
    {
        SceneManager.LoadScene("Homescene");
    }
}
