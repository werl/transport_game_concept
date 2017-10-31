using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class LoadInputsOnStart : MonoBehaviour {

	private void Awake() {
		string savePath = PathUtility.GetInputSaveFile ("/input_config.xml");
		if (System.IO.File.Exists (savePath)) {
			InputLoaderXML loader = new InputLoaderXML (savePath);
			InputManager.Load (loader);
		} else {
			Debug.Log ("No Input Config Found");
		}
	}

}
