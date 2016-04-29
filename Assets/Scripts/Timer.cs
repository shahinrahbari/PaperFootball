using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Timer : MonoBehaviour {


	public Text timer;

	public int min = 2;
	public int sec = 59;

	int interval = 1; 
	float nextTime = 0;


	// Use this for initialization
	void Start () {
	
		timer.text = "";

	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time >= nextTime) {

			//do something here every interval seconds
			setTimer();

			nextTime += interval; 

		}

	}

		public void setTimer(){
			
		timer.text = "Time Left: " + min + ":" + sec;
		sec = sec - 1;
		if (sec == 0) {
		
			min = min - 1;
		}

	
	}
}
