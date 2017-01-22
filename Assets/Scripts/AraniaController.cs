using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AraniaController : MonoBehaviour {

	public float speed = 10f;
	public Vector2 speedx     = new Vector2(0.01f,0);
	public Vector2 speedy     = new Vector2(0,0.01f);
	public Rigidbody2D rb2D;

	// Use this for initialization
	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		rb2D.MovePosition (rb2D.position + speedy);
	}
}
