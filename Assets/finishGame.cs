using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishGame : MonoBehaviour {

	bool loadScene = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player" && loadScene) {
			loadScene = false;
			StartCoroutine (Loading ());
		}
	}

	IEnumerator Loading(){
		yield return new WaitForSeconds (1);
		AsyncOperation async = Application.LoadLevelAsync (5);

		while (!async.isDone)
			yield return null;
	}
}


