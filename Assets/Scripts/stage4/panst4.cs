using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panst4 : MonoBehaviour
{
    public SpriteRenderer panmain;
    public stage4 rankSC;

    public int panfood_num3 = 0;
    public Shopitem[] pan = new Shopitem[4];
    public bool panready2 = false;
    public bool pan_material_1 = false;
    public bool pan_material_2 = false;
    public bool pan_material_3 = false;
    public bool pan_material_4 = false;
    public int material_num3 = 0;
    public Food foodcooking3;
    public SpriteRenderer picturetime3;
    public SpriteRenderer deletetobin3;
    public bool takeingaway3 = false;
    public int pantime2 = 8;
    public SpriteRenderer foodcomplete3;
    public SpriteRenderer stackpsn;
    public Food takeingfood3;
    public potricerank newpotrice;
   


    void Start()
    {
        pantime2 = 8 - PlayerPrefs.GetInt(rankSC.proppan.Propsname);
        picturetime3.gameObject.SetActive(false);
        deletetobin3.gameObject.SetActive(false);
    }


    void Update()
    {

        stackpot3();
    }


    public void clickpan3()
    {
        if (rankSC.checkfood == true && panfood_num3 < 4 && foodcooking3 == null)
        {
            pan[panfood_num3] = rankSC.itemfood[rankSC.foodselect];
            panfood_num3++;
            if (rankSC.itemfood[rankSC.foodselect].title == "rice")
            {
                newpotrice.rice[newpotrice.riceselect].gameObject.SetActive(false);
                Debug.Log("delete");
            }
            else
            {
                PlayerPrefs.SetInt(rankSC.itemfood[rankSC.foodselect].title, PlayerPrefs.GetInt(rankSC.itemfood[rankSC.foodselect].title) - 1);
                Debug.Log(PlayerPrefs.GetInt(rankSC.itemfood[rankSC.foodselect].title));
            }
        }
        if (panfood_num3 == 4 && panready2 == false)
        {
            Debug.Log("gocheck");
            deletetobin3.gameObject.SetActive(false);
            materialcheck3();
        }
        if (panfood_num3 > 0 && panfood_num3 < 4)
        {
            deletetobin3.gameObject.SetActive(true);
        }
    }
    public void materialcheck3()

    {
        Debug.Log("ccc");
        for (int i = 0; i < rankSC.foodmenupan.Length; i++)
        {
            for (int j = 0; j < pan.Length; j++)
            {
                if (pan[j].title == rankSC.foodmenupan[i].Food_material_1 && pan_material_1 == false)
                {
                    Debug.Log(rankSC.foodmenupan[i].Food_material_1);
                    pan_material_1 = true;
                    material_num3 += 1;
                }
                else if (pan[j].title == rankSC.foodmenupan[i].Food_material_2 && pan_material_2 == false)
                {
                    Debug.Log(rankSC.foodmenupan[i].Food_material_2);
                    pan_material_2 = true;
                    material_num3 += 1;
                }
                else if (pan[j].title == rankSC.foodmenupan[i].Food_material_3 && pan_material_3 == false)
                {
                    Debug.Log(rankSC.foodmenupan[i].Food_material_3);
                    pan_material_3 = true;
                    material_num3 += 1;
                }
                else if (pan[j].title == rankSC.foodmenupan[i].Food_material_4 && pan_material_4 == false)
                {
                    Debug.Log(rankSC.foodmenupan[i].Food_material_4);
                    pan_material_4 = true;
                    material_num3 += 1;
                }


            }
            if (material_num3 == 4)
            {
                panready2 = true;
                Debug.Log("ready");
                foodcooking3 = rankSC.foodmenupan[i];
                //panmain.GetComponent<SpriteRenderer>().sprite = rankSC.potclose;
                picturetime3.gameObject.SetActive(true);
                material_num3 = 0;
                return;
            }
            else
            {
                pan_material_1 = false;
                pan_material_2 = false;
                pan_material_3 = false;
                pan_material_4 = false;
                material_num3 = 0;
            }
        }

        if (material_num3 != 4)
        {
            deletetobin3.gameObject.SetActive(true);
        }
    }
    public void resetpot3()
    {
        Debug.Log("aa");
        for (int i = 0; i < pan.Length; i++)
        {
            pan[i] = null;

        }
        deletetobin3.gameObject.SetActive(false);
        panfood_num3 = 0;
        pan_material_1 = false;
        pan_material_2 = false;
        pan_material_3 = false;
        pan_material_4 = false;
    }
    public void clickmove3()
    {
        takeingfood3 = foodcooking3;
        foodcooking3 = null;
        rankSC.dish = 3;

    }
    public void stackpot3()
    {
        if (panfood_num3 == 0)
        {
            stackpsn.gameObject.SetActive(false);
        }
        else
        {
            stackpsn.gameObject.SetActive(true);
            if (panfood_num3 == 1)
            {
                stackpsn.GetComponent<SpriteRenderer>().sprite = rankSC.stack1;
            }
            else if (panfood_num3 == 2)
            {
                stackpsn.GetComponent<SpriteRenderer>().sprite = rankSC.stack2;
            }
            else if (panfood_num3 == 3)
            {
                stackpsn.GetComponent<SpriteRenderer>().sprite = rankSC.stack3;
            }
            else if (panfood_num3 == 4)
            {
                stackpsn.GetComponent<SpriteRenderer>().sprite = rankSC.stack4;
            }

        }

    }
}
