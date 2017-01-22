using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeController : MonoBehaviour {

	DataStorage dataMang;

	// Use this for initialization
	void Start () {
		GameObject dataStorageOb = GameObject.Find ("Data");
		dataMang = dataStorageOb.GetComponent<DataStorage> ();
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
