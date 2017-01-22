using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AraniaController : MonoBehaviour {

	public float speed = 10f;
	public Vector2 speedx     = new Vector2(0.02f,0);
	public Vector2 speedy     = new Vector2(0,0.02f);
	public Rigidbody2D rb2D;

	public int dir = 0;

	// Use this for initialization
	void Start() {
		rb2D = GetComponent<Rigidbody2D>();
		dir  = Random.Range(0,8);
	}

	// Update is called once per frame
	void Update () {
		if (dir == 0) {
			rb2D.MovePosition (rb2D.position + speedy);
		}
		else if (dir == 1) {
			rb2D.MovePosition (rb2D.position - speedy);
		}
		else if (dir == 2) {
			rb2D.MovePosition (rb2D.position + speedx);
		}
		else if (dir == 3) {
			rb2D.MovePosition (rb2D.position - speedx);
		}
		else if (dir == 4) {
			rb2D.MovePosition (rb2D.position + speedy + speedx);
		}
		else if (dir == 5) {
			rb2D.MovePosition (rb2D.position - speedy + speedx);
		}
		else if (dir == 6) {
			rb2D.MovePosition (rb2D.position - speedy - speedx);
		}
		else if (dir == 7) {
			rb2D.MovePosition (rb2D.position + speedy - speedx);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		dir  = Random.Range(0,8);
	}

	void OnCollisionStay2D(Collision2D coll) {
		dir  = Random.Range(0,8);
	}

}
