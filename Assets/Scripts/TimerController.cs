using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour {

	float timeLeft = 30.0f;

	void Update() {
		timeLeft -= Time.deltaTime;
		if(timeLeft >= 0)
		{
			print (timeLeft);
		}
	}
		
}
