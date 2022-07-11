using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCtrl : MonoBehaviour
{
    public string nameplayer;
    public Text showname;
    public Text showcoin;
    public int coinhome;

    public AudioSource bgsound;


    public GameObject setting;
    [SerializeField] private bool checksetting = false;
    public void Start()
    {
       
    }

    public void Update()
    {
        nameplayer = PlayerPrefs.GetString("Nameplayer");
        showname.text = nameplayer;
        coinhome = PlayerPrefs.GetInt("Coin");
        showcoin.text = coinhome.ToString();
    }

    public void backanddelete()
    {
        SceneManager.LoadScene("Startscene");
        PlayerPrefs.DeleteKey("Nameplayer");
    }
    public void Loadscene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    public void settingbutton()
    {
        checksetting = true;
        setting.gameObject.SetActive(checksetting);
    }
    public void close()
    {
        checksetting = false;
        setting.gameObject.SetActive(checksetting);
    }
    public void newgame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("createnameplayer");

    }
    public void quitgame()
    {
        Application.Quit();
       
    }
}
