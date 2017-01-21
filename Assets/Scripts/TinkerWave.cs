using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] // Execute all instances of this scripts on edit mode.
public class TinkerWave : MonoBehaviour {

	public Transform WaveOrigen;
	public float WaveDistance;
	public Material EffectMaterial;

	private Camera _camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				WaveDistance = 0;
				WaveOrigen.position = hit.point;
			}
		}
	}

	void OnEnable()
	{
		_camera = GetComponent<Camera> ();
		_camera.depthTextureMode = DepthTextureMode.Depth;
	}

	[ImageEffectOpaque]
	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		// To pass the script variable to the shader.
		EffectMaterial.SetVector("_WorldSpaceScannerPos", WaveOrigen.position);
		EffectMaterial.SetFloat("_ScanDistance", WaveDistance);
	}
}
