using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class potv2 : MonoBehaviour
{
    public SpriteRenderer potmain2;
    public timer timerSC;

    public int potfood_num2 = 0;
    public Shopitem[] pot2 = new Shopitem[4];
    public bool potready2 = false;
    public bool pot2_material_1 = false;
    public bool pot2_material_2 = false;
    public bool pot2_material_3 = false;
    public bool pot2_material_4 = false;
    public int material_num2 = 0;
    public Food foodcooking2;
    public SpriteRenderer picturetime2;
    public SpriteRenderer deletetobin2;
    public bool takeingaway2 = false;
    public int pottime2 = 8;
    public SpriteRenderer foodcomplete2;
    public SpriteRenderer stackpot_2;
    public Food takeingfood2;
    public potrice newpotrice;
    //public Food takeingfood;


    void Start()
    {
        pottime2 = 8 - PlayerPrefs.GetInt(timerSC.proppot1.Propsname);
        picturetime2.gameObject.SetActive(false);
        deletetobin2.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
        stackpot2();
    }
    

    public void clickpot2()
    {
        if (timerSC.checkfood  == true && potfood_num2 < 4&&foodcooking2 ==null)
        {
            pot2[potfood_num2] = timerSC.itemfood[timerSC.foodselect];
            potfood_num2++;
            if (timerSC.itemfood[timerSC.foodselect].title == "rice")
            {
                newpotrice.rice[newpotrice.riceselect].gameObject.SetActive(false);
                Debug.Log("delete");
            }
            else
            {
                PlayerPrefs.SetInt(timerSC.itemfood[timerSC.foodselect].title, PlayerPrefs.GetInt(timerSC.itemfood[timerSC.foodselect].title) - 1);
                Debug.Log(PlayerPrefs.GetInt(timerSC.itemfood[timerSC.foodselect].title));
            }
        }
        if (potfood_num2 == 4 && potready2 == false)
        {
            Debug.Log("gocheck");
            deletetobin2.gameObject.SetActive(false);
            materialcheck2();
        }
        if (potfood_num2 > 0 && potfood_num2 < 4)
        {
            deletetobin2.gameObject.SetActive(true);
        }
    }
    public void materialcheck2()

    {
        Debug.Log("ccc");
        for (int i = 0; i <timerSC.foodmenu.Length; i++)
        {
            for (int j = 0; j < pot2.Length; j++)
            {
                if (pot2[j].title ==timerSC.foodmenu[i].Food_material_1 && pot2_material_1 == false)
                {
                    Debug.Log(timerSC.foodmenu[i].Food_material_1);
                    pot2_material_1 = true;
                    material_num2 += 1;
                }
                else if (pot2[j].title ==timerSC.foodmenu[i].Food_material_2 && pot2_material_2 == false)
                {
                    Debug.Log(timerSC.foodmenu[i].Food_material_2);
                    pot2_material_2 = true;
                    material_num2 += 1;
                }
                else if (pot2[j].title == timerSC.foodmenu[i].Food_material_3 && pot2_material_3 == false)
                {
                    Debug.Log(timerSC. foodmenu[i].Food_material_3);
                    pot2_material_3 = true;
                    material_num2 += 1;
                }
                else if (pot2[j].title == timerSC.foodmenu[i].Food_material_4 && pot2_material_4 == false)
                {
                    Debug.Log(timerSC.foodmenu[i].Food_material_4);
                    pot2_material_4 = true;
                    material_num2 += 1;
                }

                
            }
            if (material_num2 == 4)
            {
                potready2 = true;
                Debug.Log("ready");
                foodcooking2 = timerSC.foodmenu[i];
                potmain2.GetComponent<SpriteRenderer>().sprite = timerSC.potclose;
                picturetime2.gameObject.SetActive(true);
                material_num2 = 0;
                return;
            }
            else
            {
                pot2_material_1 = false;
                pot2_material_2 = false;
                pot2_material_3 = false;
                pot2_material_4 = false;
                material_num2 = 0;
            }
        }

        if (material_num2 != 4)
        {
            deletetobin2.gameObject.SetActive(true);
        }
    }
    public void resetpot2()
    {
        Debug.Log("aa");
        for (int i = 0; i < pot2.Length; i++)
        {
            pot2[i] = null;

        }
        deletetobin2.gameObject.SetActive(false);
        potfood_num2 = 0;
        pot2_material_1 = false;
        pot2_material_2 = false;
        pot2_material_3 = false;
        pot2_material_4 = false;
    }
    public void clickmove2()
    {
        takeingfood2= foodcooking2;
        foodcooking2 = null;
        timerSC.dish = 2;

    }
    public void stackpot2()
    {
        if (potfood_num2 == 0)
        {
            stackpot_2.gameObject.SetActive(false);
        }
        else
        {
            stackpot_2.gameObject.SetActive(true);
            if (potfood_num2 == 1)
            {
                stackpot_2.GetComponent<SpriteRenderer>().sprite = timerSC.stack1;
            }
            else if (potfood_num2 == 2)
            {
                stackpot_2.GetComponent<SpriteRenderer>().sprite = timerSC.stack2;
            }
            else if (potfood_num2 == 3)
            {
                stackpot_2.GetComponent<SpriteRenderer>().sprite = timerSC.stack3;
            }
            else if (potfood_num2 == 4)
            {
                stackpot_2.GetComponent<SpriteRenderer>().sprite = timerSC.stack4;
            }

        }

    }



}
