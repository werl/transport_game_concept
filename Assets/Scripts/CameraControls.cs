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
				TileHolder tileHolder = hit.collider.GetComponentInParent<TileHolder> ();
				if (tileHolder) {
					tileHolder.ChangeTileTo (GetRoadTilePrefab(), tileHolder.GetPosition());
				}
			}
		} else if (InputManager.GetButtonDown ("Rotate")) {
			Ray ray = Camera.main.ScreenPointToRay (InputManager.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				TileBase tile = hit.collider.GetComponentInParent<TileBase> ();
				if (tile) {
					//tile.RotateTo (DirectionUtility.Rotate90(tile.GetDirection()));
					//tile.ChangeNeighbour ();
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

	private GameObject GetRoadTilePrefab() {
		GameObject o = GameObject.FindObjectOfType<StaticTiles> ()?.road;

		if (o)
			return o;
		else
			throw new System.NullReferenceException ("Couldn't find StaticTiles object");
	}

	private GameObject GetGroundTilePrefab() {
		GameObject o = GameObject.FindObjectOfType<StaticTiles> ()?.grass;

		if (o)
			return o;
		else
			throw new System.NullReferenceException ("Couldn't find StaticTiles object");
	}

}
