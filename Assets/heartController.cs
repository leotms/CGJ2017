using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartController : MonoBehaviour {

	DataStorage dataMang;
	public Image aro1;
	public Image aro2;
	public Image campana;

	// Use this for initialization
	void Start () {

		GameObject dataStorageOb = GameObject.Find ("Data");
		dataMang = dataStorageOb.GetComponent<DataStorage> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			print (dataMang.life);
			print ("DANO");
			dataMang.updateLife ();

			if ( dataMang.life == 2)
				aro1.color = new Color(0.2f, 0f,0f);
			
			if ( dataMang.life == 1)
				aro2.color = new Color(0.2f, 0f,0f);

			if ( dataMang.life == 0)
				campana.color = new Color(0.2f, 0f,0f);
		}

	}
}
