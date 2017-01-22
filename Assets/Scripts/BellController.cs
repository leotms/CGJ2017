using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Darkness"){
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}
		
}
