using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnPeopleR : MonoBehaviour
{
    public GameObject[] PeopleR;
    public GameObject pickup;
    public float spawnRate = 1f;
    float nextSpawn = 0.0f;
    
    void Start()
    {

    }


    void Update()
    {
        //humanspawR();

    }

    public void delhuman(GameObject people)
    {
        Destroy(people);
        
    }

    public void humanspawR()
    {
        if (Time.time > nextSpawn )
        {
            nextSpawn = Time.time + spawnRate;
            int Radchar = Random.Range(0, PeopleR.Length);
            pickup = Instantiate(PeopleR[Radchar], new Vector2(10.81f, -3.795006f), Quaternion.identity);
           
            //transform.Translate(new Vector2(0f, -3.0f) * speed * Time.deltaTime);

        }

    }


    public void click()
    {
        delhuman(pickup);
    }


}
