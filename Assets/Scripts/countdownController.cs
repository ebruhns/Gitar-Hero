using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;

    private void Start(){
    	StartCoroutine(Countdown());
    }


    IEnumerator Countdown(){
    	while(countdownTime > 0){
    		countdownDisplay.text = countdownTime.ToString();
    		yield return new WaitForSeconds(1f);
    		countdownTime = countdownTime - 1;
    	}
    	countdownDisplay.text = "GO!";
    	yield return new WaitForSeconds(1f);
    	countdownDisplay.gameObject.SetActive(false);
    }
}
