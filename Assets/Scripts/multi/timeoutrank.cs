using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class timeoutrank : MonoBehaviour
{
    public stagerank timerSC4;
    public GameObject timestageout;
    public GameObject games;
    public Text coinresult;
    public Text fail;
    public Text scoreresult;
    public GameObject coinUI;
    public Shopitem[] itemreward;
    public int scoreupload;
    public int randonreward;
    public Image picreward;
    public bool check = true;
    public sendscore send;

    public AudioSource soundbg;
    void Start()
    {
        if (timerSC4.times > 0)
        {
            timestageout.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(check== true){
            checktimeout();
        }
        
    }
    public void checktimeout()
    {
        if (timerSC4.times == 0)
        {
            soundbg.Stop();
            timerSC4.soundplay.PlayOneShot(timerSC4.victorysound);
            timestageout.gameObject.SetActive(true);
            games.gameObject.SetActive(false);
            scoreresult.text = timerSC4.coin.ToString();
            scoreupload = timerSC4.coin;
            
            if (scoreupload >= PlayerPrefs.GetInt(PlayerPrefs.GetString("Nameplayer"))){
                PlayerPrefs.SetInt(PlayerPrefs.GetString("Nameplayer"), scoreupload);
                send.Sumitscore();

            }
            randonreward = Random.Range(0, itemreward.Length);
            PlayerPrefs.SetInt(itemreward[randonreward].title, PlayerPrefs.GetInt(itemreward[randonreward].title) + 1);
            picreward.GetComponent<Image>().sprite = itemreward[randonreward].icon;
            check = false;
        }
    }
    public void clickBTN(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Time.timeScale = 1f;
    }
}
