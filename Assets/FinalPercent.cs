using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalPercent : MonoBehaviour
{

    public Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();
        //PlayerPrefs.SetInt("Percent", 50);
        int score = PlayerPrefs.GetInt("Percent");
        string percent = score.ToString() + "%";
        textbox.text = percent;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
