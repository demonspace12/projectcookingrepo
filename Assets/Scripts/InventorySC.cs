using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySC : MonoBehaviour

{
   
    public Shopitem[] itemlist = new Shopitem[30];
    public List<Inventoryslot> inventoryslots = new List<Inventoryslot>();
    public string saveitem;
    public Shopitem[] shopitemsinventory;




    public void Update()
    {
        UpdateslotUI();
        //checkinventory();
    }

    public void checkinventory()

    {
       
        for (int i = 0; i < shopitemsinventory.Length; i++)
        {

            if (PlayerPrefs.GetInt(shopitemsinventory[i].title) > 0)
            {
                itemlist[i] = shopitemsinventory[i];
                inventoryslots[i].item = shopitemsinventory[i];
                //add(shopitemsinventory[i]);
            }
        }
    }
    /*private bool add(Shopitem item)
    {

       
        for (int i = 0; i < itemlist.Length; i++)
        {
            if (itemlist[i] == null)
            {
                itemlist[i] = item;
                inventoryslots[i].item = item;
                //saveinventory();
                return true;
            
            }
        }
        return false;
    }*/
    
    public void UpdateslotUI()
    {
        for(int i = 0;i< inventoryslots.Count; i++)
        {
            inventoryslots[i].Updateslot();
            
        }
        
    }
    /*public void Additem(Shopitem item)
    {
        bool hasAdd = add(item);
        if (hasAdd)
        {
            //UpdateslotUI();
        }
    }*/
    
}
