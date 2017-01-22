using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darknessGenerator : MonoBehaviour {

	public GameObject darknessBlock;

	void Awake(){

		for(float i = -3.2f; i < 3.2f ; i += 0.07f){
			for(float j = -1.7f; j < 1.7f ; j += 0.07f){
				GameObject dInstance = Instantiate(darknessBlock, new Vector3(i, j, -2), Quaternion.identity);
				dInstance.transform.parent = transform;
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
