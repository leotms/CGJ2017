using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darknessGenerator : MonoBehaviour {

	public GameObject darknessBlock;

	void Awake(){

		for(float i = -0.5f; i < 0.5f ; i += 0.05f){
			for(float j = -0.5f; j < 0.5f ; j += 0.05f){
				GameObject dInstance = Instantiate(darknessBlock, new Vector3(i, j, -1), Quaternion.identity);
				dInstance.transform.parent = transform;
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
