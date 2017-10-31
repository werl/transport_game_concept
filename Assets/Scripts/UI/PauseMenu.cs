using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class PauseMenu : MonoBehaviour {

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private GameObject mainPage;

	[SerializeField]
	private GameObject controlsPage;

	[SerializeField]
	private GameObject editKeyboardPage;

	[SerializeField]
	private GameObject keyboardLayoutPage;

	[SerializeField]
	private bool openOnStart;

	private bool isOpen;

	private void Start () {
		isOpen = false;
		canvas.gameObject.SetActive (false);

		if (openOnStart)
			Open ();
	}

	private void Update() {
		if (InputManager.GetButtonDown ("PauseMenu")) {
			if (!isOpen)
				Open ();
		}
	}

	public void Open() {
		if (!isOpen && !PauseManager.IsPaused) {
			isOpen = true;
			canvas.gameObject.SetActive (true);
			ChangeToMainPage ();
			PauseManager.Pause ();
		}
	}

	public void Close() {
		if (isOpen) {
			isOpen = false;
			canvas.gameObject.SetActive (false);
			PauseManager.UnPause ();
		}
	}

	public void ChangeToMainPage() {
		controlsPage.SetActive (false);
		editKeyboardPage.SetActive (false);
		keyboardLayoutPage.SetActive (false);
		mainPage.SetActive (true);
	}

	public void ChangeToControlsPage() {
		mainPage.SetActive (false);
		editKeyboardPage.SetActive (false);
		keyboardLayoutPage.SetActive (false);
		controlsPage.SetActive (true);
	}

	public void ChangeToKeyboardEditPage() {
		mainPage.SetActive (false);
		controlsPage.SetActive (false);
		keyboardLayoutPage.SetActive (false);
		editKeyboardPage.SetActive (true);
	}

	public void ChangeToKeyboardLayoutPage() {
		mainPage.SetActive (false);
		controlsPage.SetActive (false);
		editKeyboardPage.SetActive (false);
		keyboardLayoutPage.SetActive (true);
	}

	public void Quit() {
	#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
	#else
		Application.Quit();
	#endif
	}

}
