using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : MonoBehaviour {

	public TileBase currentTile;
	private Vector2Int position;

	public void ChangeTileTo(GameObject nTile, Vector2Int pos, bool destroy = true) {
		if (destroy) {
			GameObject.Destroy (transform.GetChild (0).gameObject);
		}

		currentTile = GameObject.Instantiate (nTile, transform, false).GetComponent<TileBase> ();
		currentTile.SetPosition (pos);
	}

	public void SetPosition(Vector2Int pos) {
		this.position = pos;
	}

	public Vector2Int GetPosition() {
		return position;
	}
}
