using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventoryslot : MonoBehaviour
{
    public Shopitem item;
    public GameObject icon;
    public GameObject value;


    public void Updateslot()
    {
        
        if(item != null)
        {
            icon.GetComponent<Image>().sprite = item.icon;
            icon.SetActive(true);
            value.GetComponent<Text>().text = PlayerPrefs.GetInt(item.title).ToString();
            value.SetActive(true);


        }
        else
        {
            icon.SetActive(false);
            value.SetActive(false);
        }
    }
    
}

