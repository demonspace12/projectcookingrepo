using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmanage : MonoBehaviour
{
    public void playgame()
    {
        if (PlayerPrefs.HasKey("Nameplayer"))
        {
            Debug.Log(PlayerPrefs.GetString("Nameplayer"));
            SceneManager.LoadScene("Homescene");
        }
        else
        {
            SceneManager.LoadScene("createnameplayer");
        }
    }
}
