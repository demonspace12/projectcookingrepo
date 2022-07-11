using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zoom : MonoBehaviour
{
    public SpriteRenderer target;
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = target.bounds.size.x / target.bounds.size.y;
        if(screenRatio>= targetRatio)
        {
            Camera.main.orthographicSize = target.bounds.size.y / 2;
        }
        else
        {
            float difsize = targetRatio / screenRatio;
            Camera.main.orthographicSize = target.bounds.size.y / 2 * difsize;
        }
    }

    
}
