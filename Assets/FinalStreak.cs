using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalStreak : MonoBehaviour
{

    public Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();
       // PlayerPrefs.SetInt("Streak", 114);
        int streak = PlayerPrefs.GetInt("Streak");
        textbox.text = streak.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
