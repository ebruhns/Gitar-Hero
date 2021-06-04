using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    double score;
    int streak;
    int streak_multiplier;
    int longest_streak;
    int final_score;
    double total_notes;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        streak = 0;
        streak_multiplier = 1;
        longest_streak = 0;
        final_score = 0;
        double val = 2.0 / 3.0 * 100.0;
        print(val);
        int test = Mathf.RoundToInt((float)val);
        
        print(test);
        
    }


    public void increaseTotalNotes()
    {
        total_notes++;
    }

    public void increaseScore()
    {
        print("score increased");
        score++;
        streak++;
        if(streak > 10)
        {
            streak_multiplier = 2;
        }
        if (streak > 20)
        {
            streak_multiplier = 3;
        }
        if (streak > 40)
        {
            streak_multiplier = 4;
        }
        final_score += (25 * streak_multiplier);

        print("score: " + score);
        print("streak: " + streak);
        print("streak_multiplier " + streak_multiplier);
        print("longest_streak: " + longest_streak);
        print("final score: " + final_score);

    }

    public void brokenStreak()
    {
        if(streak > longest_streak)
        {
            longest_streak = streak;
        }
        streak = 0;
        streak_multiplier = 1;
    }

    public void songEndedHelper()
    {
        StartCoroutine(songEnded());
    }

    IEnumerator songEnded()
    {
        yield return new WaitForSeconds(3);

        double tempPercentage = (score / total_notes ) * 100.0;
        int finalPercent = Mathf.RoundToInt((float)tempPercentage);
        print("final percentage: "+finalPercent+"%");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
