using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnPeopleL : MonoBehaviour
{
    public GameObject[] PeopleL;
    
    public GameObject pickup2;

    public float spawnRate2 = 1f;
    float nextSpawn2 = 0.0f;
    

    void Start()
    {

    }


    void Update()
    {
    }

    public void delhuman2(GameObject people)
    {
        Destroy(people);
        
    }

   

    public void humanspawL()
    {
        if (Time.time > nextSpawn2 )
        {
            nextSpawn2 = Time.time + spawnRate2;
            int Radchar2 = Random.Range(0, PeopleL.Length);
            pickup2 = Instantiate(PeopleL[Radchar2], new Vector2(-10.61f, -3.795006f), Quaternion.identity);
            

        }

    }


    public void clickdpeopledel()
    {

        delhuman2(pickup2);
        //pickup2 = null;
    }


}
