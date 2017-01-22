using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tinkerController : MonoBehaviour {

	bool activate;
	bool expanded;
	bool reduce;
	float minRadius;
	float maxRadius;

	CircleCollider2D cCollider;

	float time = 5f;
	bool stopCoroutine;
	bool startedCoroutine;
	IEnumerator coroutine;

	void Start(){
		minRadius = 0.55f;
		maxRadius = 2f;
		activate = false;
		expanded = false;
		reduce = false;
		cCollider = gameObject.GetComponent<CircleCollider2D> ();

		coroutine = HideTinker ();
		startedCoroutine = false;
	}

	void Update(){

		if (Input.GetKey (KeyCode.C)) {
			activate = true;
		}

		if (activate && !expanded) {
			if (cCollider.radius < maxRadius)
				cCollider.radius += 0.1f;
			else {
				expanded = true;
				reduce = true;
			}
		}

		if (expanded && reduce) {
			if (cCollider.radius > minRadius) {
				print ("reduce");
				cCollider.radius -= 0.05f;
			} else {
				reduce = false;
				activate = false;
				expanded = false;
			}
		}

		if (expanded && !startedCoroutine) {
			StartCoroutine (coroutine);
			stopCoroutine = false;
			startedCoroutine = true;
		}

		// When the timer finish I need to set active the item.
		if (stopCoroutine) {
			StopCoroutine (coroutine);

			reduce = true;
			startedCoroutine = false;
		}
	}


 	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Darkness"){
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
    }

	IEnumerator HideTinker(){
		while (true) {
			yield return new WaitForSeconds (time);
			stopCoroutine = true;
		}
	}
}
