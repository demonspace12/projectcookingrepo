using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Shopmanager : MonoBehaviour
{
    public int coin;
    //public TMP_Text textcoin;
    public Text textcoin;
    public Shopitem[] shopitems;
    public GameObject[] shopPanelS;
    public Shoptemplete[] shoppanel;
    public GameObject invent;
    [SerializeField] private bool checkinventory = false;

    public Button[] allbutton;
    public InventorySC inventoryN;

    //inventory
    //public Shopitem[] itemlist = new Shopitem[20];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopitems.Length; i++)
        {
           
            shopPanelS[i].SetActive(true);
            Debug.Log("1");
        }
        
        LoadShop();
        checkbuy();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        coin = PlayerPrefs.GetInt("Coin");
        textcoin.text = coin.ToString();
        checkbuy();
    }
    public void addcion()
    {
        coin++;
        PlayerPrefs.SetInt("Coin", coin);
    }
    public void LoadShop()
    {
        for(int i = 0; i < shopitems.Length; i++)
        {
            shoppanel[i].titletext.text = shopitems[i].title;
            shoppanel[i].costtext.text = shopitems[i].cost.ToString()+"$";
            shoppanel[i].iconshop.GetComponent<Image>().sprite = shopitems[i].icon;
        }
    }
    public void toinventory()
    {
        //SceneManager.LoadScene("Inventoryscene");
        checkinventory = true;
        invent.gameObject.SetActive(checkinventory);

    }
    public void toshop()
    {
        checkinventory = false;
        invent.gameObject.SetActive(checkinventory);
    }
    //àªç¤à§Ô¹
    public void checkbuy()
    {
        for(int i = 0; i < shopitems.Length; i++)
        {
            if(coin >= shopitems[i].cost)
            {
                allbutton[i].interactable = true;
            }
            else
            {
                allbutton[i].interactable = false;
            }
        }
    }
    public void Buyitem(int numbutton)
    {
        if(coin>= shopitems[numbutton].cost)
        {
            coin = coin - shopitems[numbutton].cost;
            PlayerPrefs.SetInt("Coin",coin);
            textcoin.text = "Coin : " + coin.ToString();
            inventoryN.Additem(shopitems[numbutton]);
        }
       
    }
    public void backbutton()
    {
        SceneManager.LoadScene("Homescene");
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
