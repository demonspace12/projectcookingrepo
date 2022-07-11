using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scorebord : MonoBehaviour
{
    public InputField MemberID, PlayerScore;
    int MaxScores = 7;
    public Text[] Ranks, Names, Scores;


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

            Getscore();
        });


    }


    public void Sumitscore()
    {
        string memberID = PlayerPrefs.GetString("Nameplayer");
        string leaderboardID = "TestLeaderboard";
        int score = int.Parse(PlayerScore.text);

        LootLockerSDKManager.SubmitScore(memberID, score, leaderboardID, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
                Getscore();
            }

            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }



    public void Getscore()
    {
        int count = 7;
        int after = 0;
        int leaderboardID = 3575;

        LootLockerSDKManager.GetScoreListMain(leaderboardID, count, after, (response) =>
        {
            if (response.statusCode == 200)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {

                    Ranks[i].text = ("" + scores[i].rank);
                    Names[i].text = ("" + scores[i].member_id);
                    Scores[i].text = ("" + scores[i].score);
                }

                if (scores.Length < MaxScores)
                {
                    for (int i = scores.Length; i < MaxScores; i++)
                    {
                        Ranks[i].text = (i + 1).ToString();
                        Names[i].text = "";
                        Scores[i].text = "";
                    }
                }
            }

            else

            {
                Debug.Log("failed: " + response.Error);
            }
        });

    }
    public void clickbtn()
    {
        SceneManager.LoadScene("Homescene");
    }
}
