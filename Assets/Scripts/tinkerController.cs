using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class tinkerController : MonoBehaviour {

	bool activate;
	bool expanded;
	bool reduce;
	float minRadius;
	float maxRadius;

	public AudioClip Campana;
	AudioSource audio;

	CircleCollider2D cCollider;

	float time = 5f;
	bool stopCoroutine;
	bool startedCoroutine;
	IEnumerator coroutine;

	float timeToExpand = 0.6f;
	bool stopCoroutineExpand;
	bool startedCoroutineExpand;
	IEnumerator coroutineExpand;



	public Transform Tinker_Scale;
	public GameObject tinker;
	Animator tinkerAnim;

	public bool canExpand = true;

	void Start(){
		minRadius = 0.55f;
		maxRadius = 2f;
		activate = false;
		expanded = false;
		reduce = false;
		cCollider = gameObject.GetComponent<CircleCollider2D> ();

		coroutine = HideTinker ();
		startedCoroutine = false;

		coroutineExpand = WaitTime ();
		startedCoroutineExpand = false;

		tinkerAnim = tinker.GetComponent<Animator> ();
		audio = GetComponent<AudioSource>();
	}

	void Update(){

		if (Input.GetKey (KeyCode.C) && !tinkerAnim.GetCurrentAnimatorStateInfo(0).IsName("reduceTinker") && canExpand) {
			audio.PlayOneShot(Campana, 0.7F);
			activate = true;
			canExpand = false;
		}

		if (activate && !expanded) {
			tinkerAnim.SetBool ("expand", true);
			if (cCollider.radius < maxRadius) {
				cCollider.radius += 0.1f;
				Tinker_Scale.localScale += new Vector3(0.17f, 0.17f, 0);
			}else {
				expanded = true;
				reduce = true;
			}
		}
			
		if (expanded && reduce) {
			tinkerAnim.SetBool ("reduce", true);
			if (cCollider.radius > minRadius) {
				print ("reduce");
				cCollider.radius -= 0.05f;
				Tinker_Scale.localScale -= new Vector3 (0.08f, 0.08f, 0);
			} else {
				reduce = false;
				activate = false;
				expanded = false;
				tinkerAnim.SetBool ("expand", false);
				tinkerAnim.SetBool ("reduce", false);

				if (!startedCoroutineExpand) {
					StartCoroutine (coroutineExpand);
					stopCoroutineExpand = false;
					startedCoroutineExpand = true;
				}
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

		if (stopCoroutineExpand) {
			StopCoroutine (coroutineExpand);

			canExpand = true;
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

	IEnumerator WaitTime(){
		while (true) {
			yield return new WaitForSeconds (timeToExpand);
			stopCoroutineExpand = true;
		}
	}
}
