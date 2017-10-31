using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathUtility {

	public static string GetInputSaveFolder() {
		return string.Format ("{0}/Data", Application.persistentDataPath);
	}

	public static string GetInputSaveFile(string configFile) {
		return string.Format ("{0}/Data{1}", Application.persistentDataPath, configFile);
	}

}
