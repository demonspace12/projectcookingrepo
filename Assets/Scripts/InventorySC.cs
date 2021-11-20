using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySC : MonoBehaviour

{
    //public Shopitem[] allitem;
    //public string inventorydata = "";
    public Shopitem[] itemlist = new Shopitem[30];
    public List<Inventoryslot> inventoryslots = new List<Inventoryslot>();
    public string saveitem;


   
    public void Update()
    {
        UpdateslotUI();
    }
    private bool add(Shopitem item)
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
    }
    
    public void UpdateslotUI()
    {
        for(int i = 0;i< inventoryslots.Count; i++)
        {
            inventoryslots[i].Updateslot();
            
        }
        
    }
    public void Additem(Shopitem item)
    {
        bool hasAdd = add(item);
        if (hasAdd)
        {
            //UpdateslotUI();
        }
    }
    /*public void saveinventory()
    {
        if (inventorydata == null)
        {
            Debug.Log("nodata");
        }
        else
        {
            Debug.Log("aa");
        }
    }*/
}
