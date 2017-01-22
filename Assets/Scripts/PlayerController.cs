using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	public float speed = 10f;
	public Vector2 speedx     = new Vector2(0.01f,0);
	public Vector2 speedy     = new Vector2(0,0.01f);
	public Rigidbody2D rb2D;
	DataStorage dataMang;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
		rb2D = GetComponent<Rigidbody2D>();
		animator.SetInteger ("Direction", -1);

		GameObject dataStorageOb = GameObject.Find ("Data");
		dataMang = dataStorageOb.GetComponent<DataStorage> ();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			animator.SetInteger ("Direction", 0); 
			rb2D.MovePosition (rb2D.position + speedy);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			animator.SetInteger ("Direction", 1);
			rb2D.MovePosition (rb2D.position - speedy);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			animator.SetInteger ("Direction", 2);
			rb2D.MovePosition (rb2D.position + speedx);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			animator.SetInteger ("Direction", 3);
			rb2D.MovePosition (rb2D.position - speedx);
		} else {
			animator.SetInteger ("Direction", -1);
		}

		if (Input.GetKey (KeyCode.C) && dataMang.scene > 1) {
			animator.SetBool ("attack", true); 
		} else {
			animator.SetBool ("attack", false); 
		}
	}
}
