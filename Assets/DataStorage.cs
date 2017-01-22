using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour {

	public int scene;
	public int life;

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
		
	}

	public void updateScene(){
		scene++;
	}

	public void updateLife(){
		life--;
	}
}
