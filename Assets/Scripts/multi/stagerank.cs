using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stagerank : MonoBehaviour
{
    public GameObject textdisplay;
    public int times = 180;


    public int timedelay = 6;
    public int timedelay_02 = 6;

    public bool takeingaway = false;

    public bool checkdelay = false;
    public bool checkdelay_02 = false;

    public int coin = 0;
    public Text textcoin;

    public Image timebarsmain;
    public Image timebars;
    public Image timebars_02;


    public float timeremaining;
    public float timeremaining_02;

    public float maxtime = 35.0f;
    public float maxtime_02 = 35.0f;

    public float timestage = 180.0f;
    public GameObject showbartimemain;
    public GameObject showbartime;
    public GameObject showbartime_02;
    public GameObject food1;
    public GameObject food2;

    public Food[] foodmenu;
    public Food[] foodmenupan;
    public Food[] foodpot;
    public int foodrandom1;
    public int foodrandom2;

    public Image food_order1;
    public Image food_order2;


    public bool checkendstage = false;
    public GameObject endstage;

    public SpriteRenderer picturetime;
    public SpriteRenderer deletetobin;


    public SpriteRenderer potmain;

    public Sprite potclose;
    public Sprite potopen;
    public SpriteRenderer foodcomplete1;



    public Shopitem[] pot = new Shopitem[4];


    public bool checkfood = false;

    public int foodselect;
    public Shopitem[] itemfood;


    public int potfood_num = 0;

    public int material_num = 0;

    public Food foodcooking;

    private bool pot_material_1 = false;
    private bool pot_material_2 = false;
    private bool pot_material_3 = false;
    private bool pot_material_4 = false;

    //������������
    public bool potready = false;

    public int pottime = 8;

    public SpriteRenderer stackpot_1;
    public Sprite stack1;
    public Sprite stack2;
    public Sprite stack3;
    public Sprite stack4;


    public Food takeingfood;
    public Food foodmove;
    public bool checkmove;
    public bool checkbill_1 = false;
    public bool checkbill_2 = false;
    public int checktime1 = 2;
    public int checktime2 = 2;

    public SpriteRenderer ordercomplete1;
    public SpriteRenderer ordercomplete2;
    public int dish = 0;

    public potrank pot2st2;
    public potricerank pot_rice;

    public Propkitchen proppot1;
    public Propkitchen proppan;

    public Food salmonfood;

    public Button foodbtn1;
    public Button foodbtn2;

    public panrank pannew;

    public bool waittimefood = false;
    public bool waittimefood2 = false;
    public float waittime;
    public float waittime2;
    public SpawnPeopleL peopleleft;
    public SpawnPeopleR peopleright;

    public AudioSource soundplay;

    public AudioClip foodding;
    public AudioClip failsound;
    public AudioClip victorysound;
    public AudioClip checkbillsound;



    void Start()
    {
        soundplay.GetComponent<AudioSource>();
       
        pottime = 8 - PlayerPrefs.GetInt(proppot1.Propsname);
        Debug.Log("startgame");

        textdisplay.GetComponent<Text>().text = times.ToString();

        picturetime.gameObject.SetActive(false);
        deletetobin.gameObject.SetActive(false);
    }


    void Update()
    {

        textcoin.text = coin.ToString();



        if (takeingaway == false)
        {
            StartCoroutine(timertake());
        }
        timebarcoutdown();
        stackpot1();

        if (times == 0)
        {

            peopleleft.clickdpeopledel();
            peopleright.click();
        }

    }

    IEnumerator timertake()
    {
        takeingaway = true;
        yield return new WaitForSeconds(1);
        if (waittimefood == true)
        {
            waittime -= 1;
            if (waittime == 0)
            {
                peopleleft.clickdpeopledel();
                waittimefood = false;
            }
        }
        if (waittimefood2 == true)
        {
            waittime2 -= 1;
            if (waittime2 == 0)
            {
                peopleright.click();
                waittimefood2 = false;
            }
        }
        if (checkdelay == true)
        {
            timedelay -= 1;
            if (timedelay == 2)
            {
                peopleleft.humanspawL();
                Debug.Log("randomleft");
            }
            if (timedelay == 0)
            {
                showbartime.SetActive(true);
                food1.SetActive(true);
                randomfood(1);
                maxtime = 45.0f;
                timeremaining = maxtime;
                timedelay = 5;
                waittime = maxtime;
                waittimefood = true;
                checkdelay = false;

            }
        }
        if (checkdelay_02 == true)
        {
            timedelay_02 -= 1;
            if (timedelay_02 == 2)
            {
                peopleright.humanspawR();
                Debug.Log("random");
            }
            if (timedelay_02 == 0)
            {

                showbartime_02.SetActive(true);

                food2.SetActive(true);
                randomfood(2);
                maxtime_02 = 45.0f;
                timeremaining_02 = maxtime_02;
                timedelay_02 = 5;
                waittime2 = maxtime;
                waittimefood2 = true;
                checkdelay_02 = false;

            }
        }
        if (potready == true)
        {
            pottime -= 1;
            if (pottime == 0)
            {
                soundplay.PlayOneShot(foodding);
                picturetime.gameObject.SetActive(false);
                potmain.GetComponent<SpriteRenderer>().sprite = potopen;
                foodcomplete1.GetComponent<SpriteRenderer>().sprite = foodcooking.foodicon;
                foodcomplete1.gameObject.SetActive(true);

                pot_material_1 = false;
                pot_material_2 = false;
                pot_material_3 = false;
                pot_material_4 = false;

                potfood_num = 0;
                resetpot();
                pottime = 8 - PlayerPrefs.GetInt(proppot1.Propsname);
                potready = false;
            }
        }
        if (pot2st2.potready2 == true)
        {
            pot2st2.pottime2 -= 1;
            if (pot2st2.pottime2 == 0)
            {
                soundplay.PlayOneShot(foodding);
                pot2st2.picturetime2.gameObject.SetActive(false);
                pot2st2.potmain2.GetComponent<SpriteRenderer>().sprite = potopen;
                pot2st2.foodcomplete2.GetComponent<SpriteRenderer>().sprite = pot2st2.foodcooking2.foodicon;
                pot2st2.foodcomplete2.gameObject.SetActive(true);

                pot2st2.pot2_material_1 = false;
                pot2st2.pot2_material_2 = false;
                pot2st2.pot2_material_3 = false;
                pot2st2.pot2_material_4 = false;

                pot2st2.potfood_num2 = 0;
                pot2st2.resetpot2();
                pot2st2.pottime2 = 8 - PlayerPrefs.GetInt(proppot1.Propsname);
                pot2st2.potready2 = false;
            }
        }
        if (pannew.panready2 == true)
        {
            pannew.pantime2 -= 1;
            if (pannew.pantime2 == 0)
            {
                soundplay.PlayOneShot(foodding);
                pannew.picturetime3.gameObject.SetActive(false);
                //pannew.panmain.GetComponent<SpriteRenderer>().sprite = potopen;
                pannew.foodcomplete3.GetComponent<SpriteRenderer>().sprite = pannew.foodcooking3.foodicon;
                pannew.foodcomplete3.gameObject.SetActive(true);

                pannew.pan_material_1 = false;
                pannew.pan_material_2 = false;
                pannew.pan_material_3 = false;
                pannew.pan_material_4 = false;

                pannew.panfood_num3 = 0;
                pannew.resetpot3();
                pannew.pantime2 = 8 - PlayerPrefs.GetInt(proppan.Propsname);
                pannew.panready2 = false;
            }
        }
        if (pot_rice.potriceready == true)
        {
            pot_rice.potricetime -= 1;
            if (pot_rice.potricetime == 0)
            {


                pot_rice.potricemain.GetComponent<SpriteRenderer>().sprite = pot_rice.potricenormal;
                for (int i = 0; i < pot_rice.rice.Length; i++)
                {
                    pot_rice.rice[i].gameObject.SetActive(true);
                }






                pot_rice.potricetime = 7 - PlayerPrefs.GetInt(pot_rice.proppotrice.Propsname);
                pot_rice.potriceready = false;
            }
        }

        if (checkbill_1 == true)
        {
            checktime1 -= 1;
            if (checktime1 == 0)
            {
                checkbill1();
                checkbill_1 = false;
                ordercomplete1.gameObject.SetActive(false);
                checktime1 = 2;
                timeremaining = 0;
                peopleleft.clickdpeopledel();


            }
        }
        if (checkbill_2 == true)
        {
            checktime2 -= 1;
            if (checktime2 == 0)
            {
                checkbill2();
                checkbill_2 = false;
                ordercomplete2.gameObject.SetActive(false);
                checktime2 = 2;
                timeremaining_02 = 0;
                peopleright.click();
            }
        }


        times -= 1;
        textdisplay.GetComponent<Text>().text = times.ToString();

        takeingaway = false;
        if (times == 0)
        {
            takeingaway = true;
        }
    }
    public void backbutton()
    {
        SceneManager.LoadScene("Mapselectscene");
    }
    public void timebarcoutdown()
    {
        if (timeremaining > 0 && waittime > 0)
        {
            foodbtn1.interactable = true;
            timeremaining -= Time.deltaTime;
            timebars.fillAmount = timeremaining / maxtime;

        }
        else
        {
            foodbtn1.interactable = false;
            showbartime.SetActive(false);

            food1.SetActive(false);

            checkdelay = true;
        }
        if (timeremaining_02 > 0 && waittime2 > 0)
        {
            foodbtn2.interactable = true;
            timeremaining_02 -= Time.deltaTime;

            timebars_02.fillAmount = timeremaining_02 / maxtime_02;
        }
        else
        {
            foodbtn2.interactable = false;
            showbartime_02.SetActive(false);

            food2.SetActive(false);
            checkdelay_02 = true;
        }
    }

    public void randomfood(int num)
    {
        if (num == 1)
        {
            foodrandom1 = Random.Range(0, foodmenu.Length);
            food_order1.GetComponent<Image>().sprite = foodmenu[foodrandom1].foodicon;
            /*if (PlayerPrefs.GetInt(salmonfood.foodname) > 0)
            {
                foodrandom1 = Random.Range(0, foodmenu.Length);
                food_order1.GetComponent<Image>().sprite = foodmenu[foodrandom1].foodicon;
            }
            else
            {
                foodrandom1 = Random.Range(0, foodmenu.Length - 1);
                food_order1.GetComponent<Image>().sprite = foodmenu[foodrandom1].foodicon;
            }*/
        }

        if (num == 2)
        {
            foodrandom2 = Random.Range(0, foodmenu.Length);
            food_order2.GetComponent<Image>().sprite = foodmenu[foodrandom2].foodicon;
            /*if (PlayerPrefs.GetInt(salmonfood.foodname) > 0)
            {
                foodrandom2 = Random.Range(0, foodmenu.Length);
                food_order2.GetComponent<Image>().sprite = foodmenu[foodrandom2].foodicon;
            }
            else
            {
                foodrandom2 = Random.Range(0, foodmenu.Length - 1);
                food_order2.GetComponent<Image>().sprite = foodmenu[foodrandom2].foodicon;
            }*/
        }

    }

    public void clickfood(int numberfood)
    {
        foodselect = numberfood;
        checkfood = true;
        Debug.Log(foodselect);
        Debug.Log(itemfood[foodselect]);


    }
    public void clickpot()
    {
        if (checkfood == true && potfood_num < 4&&foodcooking==null)
        {
            pot[potfood_num] = itemfood[foodselect];
            potfood_num++;
            if (itemfood[foodselect].title == "rice")
            {
                pot_rice.rice[pot_rice.riceselect].gameObject.SetActive(false);
                Debug.Log("delete");
            }
        }
        if (potfood_num == 4 && potready == false)
        {
            Debug.Log("gocheck");
            deletetobin.gameObject.SetActive(false);
            materialcheck();
        }
        if (potfood_num > 0 && potfood_num < 4)
        {
            deletetobin.gameObject.SetActive(true);
        }
    }

    public void materialcheck()

    {

        Debug.Log("ccc");
        for (int i = 0; i < foodpot.Length; i++)
        {
            for (int j = 0; j < pot.Length; j++)
            {
                
                if (pot[j].title == foodpot[i].Food_material_1 && pot_material_1 == false)
                {
                    Debug.Log(foodpot[i].Food_material_1);
                    pot_material_1 = true;
                    material_num += 1;
                }
                else if (pot[j].title == foodpot[i].Food_material_2 && pot_material_2 == false)
                {
                    Debug.Log(foodpot[i].Food_material_2);
                    pot_material_2 = true;
                    material_num += 1;
                }
                else if (pot[j].title == foodpot[i].Food_material_3 && pot_material_3 == false)
                {
                    Debug.Log(foodpot[i].Food_material_3);
                    pot_material_3 = true;
                    material_num += 1;
                }
                else if (pot[j].title == foodpot[i].Food_material_4 && pot_material_4 == false)
                {
                    Debug.Log(foodpot[i].Food_material_4);
                    pot_material_4 = true;
                    material_num += 1;
                }


            }
            if (material_num == 4)
            {
                potready = true;
                Debug.Log("ready");
                foodcooking = foodpot[i];
                Debug.Log(foodcooking.foodname);
                potmain.GetComponent<SpriteRenderer>().sprite = potclose;
                picturetime.gameObject.SetActive(true);
                material_num = 0;
                return;
            }
            else
            {
                pot_material_1 = false;
                pot_material_2 = false;
                pot_material_3 = false;
                pot_material_4 = false;
                material_num = 0;
            }
        }

        if (material_num != 4)
        {
            deletetobin.gameObject.SetActive(true);
        }
    }


    public void resetpot()
    {
        Debug.Log("aa");
        for (int i = 0; i < pot.Length; i++)
        {
            pot[i] = null;

        }
        deletetobin.gameObject.SetActive(false);
        potfood_num = 0;
        pot_material_1 = false;
        pot_material_2 = false;
        pot_material_3 = false;
        pot_material_4 = false;
    }
    public void stackpot1()
    {
        if (potfood_num == 0)
        {
            stackpot_1.gameObject.SetActive(false);
        }
        else
        {
            stackpot_1.gameObject.SetActive(true);
            if (potfood_num == 1)
            {
                stackpot_1.GetComponent<SpriteRenderer>().sprite = stack1;
            }
            else if (potfood_num == 2)
            {
                stackpot_1.GetComponent<SpriteRenderer>().sprite = stack2;
            }
            else if (potfood_num == 3)
            {
                stackpot_1.GetComponent<SpriteRenderer>().sprite = stack3;
            }
            else if (potfood_num == 4)
            {
                stackpot_1.GetComponent<SpriteRenderer>().sprite = stack4;
            }

        }

    }
    public void clickmove()
    {
        takeingfood = foodcooking;
        foodcooking = null;
        dish = 1;

    }

    public void bill1()
    {


        if (dish == 1)
        {
            checkbill_1 = true;
            ordercomplete1.gameObject.SetActive(true);
            ordercomplete1.GetComponent<SpriteRenderer>().sprite = takeingfood.foodicon;
            foodcomplete1.gameObject.SetActive(false);
        }
        else if (dish == 2)
        {
            checkbill_1 = true;
            ordercomplete1.gameObject.SetActive(true);
            ordercomplete1.GetComponent<SpriteRenderer>().sprite = pot2st2.takeingfood2.foodicon;
            pot2st2.foodcomplete2.gameObject.SetActive(false);
        }
        else if (dish == 3)
        {
            checkbill_1 = true;
            ordercomplete1.gameObject.SetActive(true);
            ordercomplete1.GetComponent<SpriteRenderer>().sprite = pannew.takeingfood3.foodicon;
            pannew.foodcomplete3.gameObject.SetActive(false);
        }
        else
        {
            return;
        }


    }
    public void checkbill1()
    {

        if (dish == 1)

        {
            if (foodmenu[foodrandom1].foodname == takeingfood.foodname)
            {
                coin += 50;
                soundplay.PlayOneShot(checkbillsound);
                
            }
            else
            {
                coin -= 10;
            }
            foodcooking = null;
            takeingfood = null;
            dish = 0;
        }
        else if (dish == 2)
        {
            if (foodmenu[foodrandom1].foodname == pot2st2.takeingfood2.foodname)
            {
                coin += 50;
                soundplay.PlayOneShot(checkbillsound);

            }
            else
            {
                coin -= 10;
            }
            pot2st2.foodcooking2 = null;
            pot2st2.takeingfood2 = null;
            dish = 0;
        }
        else if (dish == 3)
        {
            if (foodmenu[foodrandom1].foodname == pannew.takeingfood3.foodname)
            {
                coin += 50;
                soundplay.PlayOneShot(checkbillsound);

            }
            else
            {
                coin -= 10;
            }
            pannew.foodcooking3 = null;
            pannew.takeingfood3 = null;
            dish = 0;
        }
    }
    public void bill2()
    {


        if (dish == 1)
        {
            checkbill_2 = true;
            ordercomplete2.gameObject.SetActive(true);
            ordercomplete2.GetComponent<SpriteRenderer>().sprite = takeingfood.foodicon;
            foodcomplete1.gameObject.SetActive(false);
        }
        else if (dish == 2)
        {
            checkbill_2 = true;
            ordercomplete2.gameObject.SetActive(true);
            ordercomplete2.GetComponent<SpriteRenderer>().sprite = pot2st2.takeingfood2.foodicon;
            pot2st2.foodcomplete2.gameObject.SetActive(false);
        }
        else if (dish == 3)
        {
            checkbill_2 = true;
            ordercomplete2.gameObject.SetActive(true);
            ordercomplete2.GetComponent<SpriteRenderer>().sprite =pannew.takeingfood3.foodicon;
            pannew.foodcomplete3.gameObject.SetActive(false);
        }
        else
        {
            return;
        }

    }
    public void checkbill2()
    {

        if (dish == 1)
        {
            if (foodmenu[foodrandom2].foodname == takeingfood.foodname)
            {
                coin += 50;
                soundplay.PlayOneShot(checkbillsound);
            }
            else
            {
                coin -= 10;
            }
            foodcooking = null;
            takeingfood = null;
            dish = 0;
        }
        else if (dish == 2)
        {
            if (foodmenu[foodrandom2].foodname == pot2st2.takeingfood2.foodname)
            {
                coin += 50;
                soundplay.PlayOneShot(checkbillsound);
            }
            else
            {
                coin -= 10;
            }
            pot2st2.foodcooking2 = null;
            pot2st2.takeingfood2 = null;
            dish = 0;
        }
        else if (dish == 3)
        {
            if (foodmenu[foodrandom2].foodname == pannew.takeingfood3.foodname)
            {
                coin += 50;
                soundplay.PlayOneShot(checkbillsound);
            }
            else
            {
                coin -= 10;
            }
            pannew.foodcooking3 = null;
            pannew.takeingfood3 = null;
            dish = 0;
        }

    }
    public void deletefood()
    {
        if (dish == 1 && takeingfood != null)
        {
            foodcomplete1.gameObject.SetActive(false);
            foodcooking = null;
            takeingfood = null;
            dish = 0;
        }
        else if (dish == 2 && pot2st2.takeingfood2 != null)
        {
            pot2st2.foodcomplete2.gameObject.SetActive(false);
            pot2st2.foodcooking2 = null;
            pot2st2.takeingfood2 = null;
            dish = 0;
        }
        else if (dish == 3 && pannew.takeingfood3 != null)
        {
            pannew.foodcomplete3.gameObject.SetActive(false);
            pannew.foodcooking3 = null;
            pannew.takeingfood3 = null;
            dish = 0;
        }
        else
        {
            return;
        }

    }
}
