using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class SaveInputs : MonoBehaviour {

	public void Save() {
		string saveFolder = PathUtility.GetInputSaveFolder ();
		if (!System.IO.Directory.Exists (saveFolder)) {
			System.IO.Directory.CreateDirectory (saveFolder);
		}

		InputSaverXML saver = new InputSaverXML(PathUtility.GetInputSaveFile("/input_config.xml"));
		InputManager.Save (saver);
	}
}
