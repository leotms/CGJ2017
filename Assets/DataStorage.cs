using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour {

	public int scene;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		scene = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateScene(){
		scene++;
	}
}
