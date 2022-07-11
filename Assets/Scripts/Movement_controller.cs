using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_controller : MonoBehaviour
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
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(5.777779f, -3.795006f), 2f * Time.deltaTime);
    }

}
