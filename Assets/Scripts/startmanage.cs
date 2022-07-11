using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startmanage : MonoBehaviour
{
    public float unit;
    public Image fill;
    private float fillAmount;

    public GameObject button;
    public GameObject load;
    public void Start()
    {
        StartCoroutine(build());
    }
    public void Update()
    {
        updatebar();
    }
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
    public IEnumerator build()
    {
        for (int i = 0; i <= unit; i++)
        {
            fillAmount = i / unit;
            yield return null;
        }
        load.SetActive(false);
        button.SetActive(true);
    }
    
    private void updatebar()
    {
        fill.fillAmount = fillAmount;
    }
}
