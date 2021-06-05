using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{

    public Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        
        //PlayerPrefs.SetInt("Score", 20);
        int score = PlayerPrefs.GetInt("Score");
        textbox.text = score.ToString(); 
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
