using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartController : MonoBehaviour {

	int life;

	// Use this for initialization
	void Start () {
		life = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			life -= 1;
			print (life);
		}

	}
}
