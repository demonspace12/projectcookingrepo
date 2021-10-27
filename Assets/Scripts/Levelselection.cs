using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levelselection : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public Image unlockImage;
    public GameObject[] star;
    public Sprite starfill;

    public void Update()
    {
        updatelevelImage();
        updatestatuslevel();
    }

    private void updatelevelImage()
    {
        if (!unlocked)
        {
            unlockImage.gameObject.SetActive(true);

            for(int i = 0; i < star.Length; i++)
            {
                star[i].gameObject.SetActive(false);
            }
        }
        else
        {
            unlockImage.gameObject.SetActive(false);
            for(int i = 0; i < star.Length; i++)
            {
                star[i].gameObject.SetActive(true);
            }
            for(int i = 0; i < PlayerPrefs.GetInt("lv" + gameObject.name); i++)
            {
                star[i].gameObject.GetComponent<Image>().sprite = starfill;
            }
        }
    }
    private void updatestatuslevel()
    {
       int beforelevel = int.Parse(gameObject.name) - 1;
        if(beforelevel == 0)
        {
            unlocked = true;
        }
        
        else if (PlayerPrefs.GetInt("lv" + beforelevel) > 0)
        {
            unlocked = true;
        }
    }
    public void clicklevel(string levelname)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(levelname);
        }  
    }
    public void clearpref()
    {
        PlayerPrefs.DeleteAll();
    }
    
}
