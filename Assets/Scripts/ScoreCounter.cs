using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
       
  


    }


    public void increaseTotalNotes()
    {
        total_notes++;
    }

    public void increaseScore()
    {
        
        score++;
        print(streak);
        streak++;
        if(streak == 10)
        {
            streak_multiplier = 2;
            print("hi");

        }
        if (streak== 20)
        {
            streak_multiplier = 3;
 
        }
        if (streak == 40)
        {
            streak_multiplier = 4;

        }
        final_score += (25 * streak_multiplier);

 

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

        PlayerPrefs.SetInt("Score", final_score);
        PlayerPrefs.SetInt("Percent", finalPercent); 

        PlayerPrefs.SetInt("Streak", longest_streak);

        SceneManager.LoadScene("ScoreScene");




    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
