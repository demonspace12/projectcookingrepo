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
}
