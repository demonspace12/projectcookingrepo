using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timeoutst5 : MonoBehaviour
{
    public stage5 timerSC4;
    public GameObject timestageout;
    public GameObject games;
    public Text coinresult;
    public GameObject[] starresult;
    public scorest5 scoreSC;
    public Text fail;
    public GameObject reward;
    public GameObject coinUI;
    public int level;
    public bool roundcheck = false;
    public Shopitem salmonitem;
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
        if (roundcheck == false)
        {
            checktimeout();
        }
    }
    public void checktimeout()
    {
        if (timerSC4.times == 0)
        {
            soundbg.Stop();
            timestageout.gameObject.SetActive(true);
            games.gameObject.SetActive(false);
            coinresult.text = timerSC4.coin.ToString();
            if (scoreSC.currentstar == 0)
            {
                timerSC4.soundplay.PlayOneShot(timerSC4.failsound);
                coinresult.gameObject.SetActive(false);
                fail.text = "FAIL !!!";
                reward.gameObject.SetActive(false);
                coinUI.gameObject.SetActive(false);
            }
            else
            {
                timerSC4.soundplay.PlayOneShot(timerSC4.victorysound);
                for (int i = 0; i < scoreSC.currentstar; i++)
                {
                    starresult[i].gameObject.GetComponent<Image>().sprite = scoreSC.starfill;
                }
                PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + timerSC4.coin);
            }
            if (PlayerPrefs.GetInt(salmonitem.title) < 3)
            {
                PlayerPrefs.SetInt(salmonitem.title, PlayerPrefs.GetInt(salmonitem.title) + 1);
            }
            if (scoreSC.currentstar > PlayerPrefs.GetInt("lv" + level))
            {
                Debug.Log(PlayerPrefs.GetInt("lv" + level));
                PlayerPrefs.SetInt("lv" + level, scoreSC.currentstar);
            }
            Debug.Log(PlayerPrefs.GetInt("lv" + level));
            roundcheck = true;
        }
    }
    public void clickBTN(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Time.timeScale = 1f;
    }
}
