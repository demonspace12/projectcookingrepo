using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;

public class sendscore : MonoBehaviour
{
    //int MaxScores = 7;
    public stagerank rank;
    // Start is called before the first frame update
    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");

            
        });
    }
    public void Sumitscore()
    {
        string memberID = PlayerPrefs.GetString("Nameplayer");
        string leaderboardID = "TestLeaderboard";
        int score = PlayerPrefs.GetInt(PlayerPrefs.GetString("Nameplayer"));

        LootLockerSDKManager.SubmitScore(memberID, score, leaderboardID, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
               
            }

            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
