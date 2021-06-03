using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DelayStart : MonoBehaviour
{
	public GameObject Countdown;
	public int countdownTime;
    public Text countdownDisplay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartDelay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartDelay(){
    	Time.timeScale = 0;
    	float pauseTime = Time.realtimeSinceStartup + 3f;
    	while(Time.realtimeSinceStartup < pauseTime){
    		yield return 0;
    	}
    	Countdown.gameObject.SetActive(false);
    	Time.timeScale = 1;
    }
}
