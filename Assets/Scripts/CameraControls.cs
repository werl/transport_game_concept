using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class CameraControls : MonoBehaviour {

	public float speedModifier = 10f;
	
	// Update is called once per frame
	void Update () {
		if (InputManager.GetButtonDown ("Select")) {
			Ray ray = Camera.main.ScreenPointToRay (InputManager.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.GetComponent<Tile> ()) {
					Tile t = hit.collider.GetComponent<Tile> ();
					t.ChangeTile ();
				}
			}
		} else if (InputManager.GetButtonDown ("Rotate")) {
			Ray ray = Camera.main.ScreenPointToRay (InputManager.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.GetComponent<Tile> ()) {
					Tile t = hit.collider.GetComponent<Tile> ();
					t.rotate ();
				}
			}
		} 
		if (InputManager.GetAxis ("Horizontal") != 0f) {
			float speed = InputManager.GetAxis ("Horizontal") * speedModifier * Time.deltaTime;
			transform.Translate (speed, 0, 0);
		}
		if (InputManager.GetAxis ("Vertical") != 0f) {
			float speed = InputManager.GetAxis ("Vertical") * speedModifier * Time.deltaTime;
			transform.Translate (0, 0, speed);
		}
	}

}
