using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

	float time = 0.05f;
	bool canShow = true;
	bool stopCoroutine;
	bool startedCoroutine;
	IEnumerator coroutine;
	GameObject children;

	// Use this for initialization
	void Start () {
		coroutine = ActiveBlock ();
		startedCoroutine = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameObject.GetComponent<SpriteRenderer>().enabled && !startedCoroutine && canShow) {
			StartCoroutine (coroutine);
			stopCoroutine = false;
			startedCoroutine = true;
		}

		// When the timer finish I need to set active the item.
		if (stopCoroutine) {
			StopCoroutine (coroutine);

			gameObject.GetComponent<BoxCollider2D> ().enabled = true;

			if (canShow) {
				gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			}
			startedCoroutine = false;
		}
	}

	// This let you know when the pickut will activate.
	IEnumerator ActiveBlock(){
		while (true) {
			yield return new WaitForSeconds (time);
			stopCoroutine = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Tinker"){
			canShow = false;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		canShow = true;
	}
}
