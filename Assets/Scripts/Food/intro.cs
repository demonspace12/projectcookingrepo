using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour
{
    public GameObject showintro;
    // Start is called before the first frame update
    void Start()
    {
        showintro.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickclose()
    {
        showintro.gameObject.SetActive(false);
    }
    public void openintro()
    {
        showintro.gameObject.SetActive(true);
    }
}
