using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMentLeft : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {
        RunAnyway();
    }

     void RunAnyway()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-4.98f, -3.795006f), 2f * Time.deltaTime);
    }
}
