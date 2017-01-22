using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

	float timeLeft = 30.0f;
	public Text timer;
	bool loadScene = true;

	void Start(){
		timer.color = new Color(0.72f, 0.7f, 0.14f);
	}

	void Update() {
		timeLeft -= Time.deltaTime;
		if(timeLeft >= 0)
		{
			UpdateText ();
		}

		if (timeLeft <= 0 && loadScene) {
			loadScene = false;
			StartCoroutine (Loading ());
		}
	}
		
	void UpdateText(){
		if (timeLeft >= 10)
			timer.text = "Sobrevive hasta que se acabe el tiempo: " + timeLeft.ToString ("N0");
		else {
			timer.text = "Sobrevive hasta que se acabe el tiempo: 0" + timeLeft.ToString ("N0");
		}
	}

	IEnumerator Loading(){
		yield return new WaitForSeconds (1);
		AsyncOperation async = Application.LoadLevelAsync (4);

		while (!async.isDone)
			yield return null;
	}

}
