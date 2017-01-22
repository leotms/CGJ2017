using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour {

	public int scene;
	public int life;
	bool loadScene = true;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		scene = 0;
		life = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (life == 0 && loadScene) {
			loadScene = false;
			StartCoroutine (Loading ());
		}
	}

	public void updateScene(){
		scene++;
	}

	public void updateLife(){
		life--;
	}

	IEnumerator Loading(){
		yield return new WaitForSeconds (1);
		AsyncOperation async = Application.LoadLevelAsync (5);

		while (!async.isDone)
			yield return null;
	}
}
