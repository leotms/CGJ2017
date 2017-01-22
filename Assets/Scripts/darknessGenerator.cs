using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darknessGenerator : MonoBehaviour {

	public GameObject darknessBlock;
	public float limitx;
	public float limity;

	void Awake(){

		for(float i = -limitx; i < limitx ; i += 0.05f){
			for(float j = -limity; j < limity ; j += 0.05f){
				GameObject dInstance = Instantiate(darknessBlock, new Vector3(i, j, -1), Quaternion.identity);
				dInstance.transform.parent = transform;
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
