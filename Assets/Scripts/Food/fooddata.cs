using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fooddata : MonoBehaviour
{
    
    public void btn(string namescene) 
    {
        SceneManager.LoadScene(namescene);
    }
}
