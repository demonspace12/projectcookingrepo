using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Shopmanager : MonoBehaviour
{
    public int coin;
    public TMP_Text textcoin;
    public Shopitem[] shopitems;
    public GameObject[] shopPanelS;
    public Shoptemplete[] shoppanel;

    //inventory
    //public Shopitem[] itemlist = new Shopitem[20];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopitems.Length; i++)
        {
           
            shopPanelS[i].SetActive(true);
        }
        textcoin.text = "Coin : " + coin.ToString();
        LoadShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addcion()
    {
        coin++;
        textcoin.text = "Coin : " + coin.ToString();
    }
    public void LoadShop()
    {
        for(int i = 0; i < shopitems.Length; i++)
        {
            shoppanel[i].titletext.text = shopitems[i].title;
            shoppanel[i].costtext.text = shopitems[i].cost.ToString()+"$";
        }
    }
    public void toinventory()
    {
        SceneManager.LoadScene("Inventoryscene");
    }
    /*public  bool additemtoinventory(Shopitem item) { 
        for(int i=0 ; i<itemlist.Length; i++)
        {
            if(itemlist[i] == null)
            {
                itemlist[i] = item;
                return true;
            }
        }
        return false;
    }*/
}
