using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class CameraControls : MonoBehaviour {

	public float speedModifier = 10f;

	private GameObject roadTilePrefab;
	private GameObject groundTilePrefab;

	void Start() {
		roadTilePrefab = GameObject.FindObjectOfType<StaticTiles> ()?.road;
		groundTilePrefab = GameObject.FindObjectOfType<StaticTiles> ()?.grass;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.GetButtonDown ("Select")) {
			Ray ray = Camera.main.ScreenPointToRay (InputManager.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				TileHolder tileHolder = hit.collider.GetComponentInParent<TileHolder> ();
				if (tileHolder && !(tileHolder.GetCurrentTile() is TileRoad)) {
					tileHolder.ChangeTileTo (roadTilePrefab, tileHolder.GetPosition());
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

}
