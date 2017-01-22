using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnStart : MonoBehaviour {
	bool loadScene = true;
	// Use this for initialization
	void Start () {

	}

	// Updates once per frame
	void Update() {

		// If the player has pressed the space bar and a new scene is not loading yet...
		if (Input.GetKey(KeyCode.C) && loadScene) {
			loadScene = false;
			// ...and start a coroutine that will load the desired scene.
			StartCoroutine(LoadNewScene());

		}

		// If the player has pressed the space bar and a new scene is not loading yet...
		if (Input.GetKey(KeyCode.C) && loadScene) {
			loadScene = false;
			// ...and start a coroutine that will load the desired scene.
			StartCoroutine(Controlescene());

		}

	}


	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene() {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds(1);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		AsyncOperation async = Application.LoadLevelAsync(4);

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone) {
			yield return null;
		}

	}

	IEnumerator Controlescene() {

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds(1);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		AsyncOperation async = Application.LoadLevelAsync(0);

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone) {
			yield return null;
		}

	}
}
