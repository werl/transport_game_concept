using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public GameObject grass;
	public GameObject road;
	public GameObject road_T;
	public GameObject road_X;

	private int type;
	private int rotation;
	private Vector3 startPos;
	private Quaternion startRotate;

	void Start () {
		startPos = transform.position;
		startRotate = transform.rotation;
		ChangeTileInternal (grass, 0, false);

	}
	
	void Update () {
	}

	public void ChangeTile() {
		if (type == 0) {
			ChangeTileInternal (road, 1);
		} else if (type == 1) {
			ChangeTileInternal (road_T, 2);
		} else if (type == 2) {
			ChangeTileInternal (road_X, 3);
		} else if (type == 3) {
			ChangeTileInternal (grass, 0);
		}
	}

	private void ChangeTileInternal(GameObject tile, int type, bool destroy = true) {
		if (destroy) {
			GameObject.Destroy (transform.GetChild (0).gameObject);
		}

		transform.position = startPos;
		transform.rotation = startRotate;

		GameObject g = GameObject.Instantiate (tile);
		g.transform.parent = transform;
		g.transform.position = startPos;

		this.type = type;
		rotation = 0;

		MeshFilter filter = g.GetComponentInChildren<MeshFilter> ();
		gameObject.GetComponent<MeshCollider> ().sharedMesh = filter.mesh;
	}

	public void rotate () {
		if (type == 0) {
			// NO-OP
		} else if (type == 1) {
			if (rotation == 0) {
				transform.Rotate (new Vector3 (0, 90, 0));
				Vector3 v = transform.position;
				v.z -= 3;
				transform.position = v;
				rotation = 1;
			} else {
				transform.Rotate (new Vector3 (0, -90, 0));
				Vector3 v = transform.position;
				v.z += 3;
				transform.position = v;
				rotation = 0;
			}
		} else if (type == 2) {
			if (rotation == 0) {
				transform.Rotate (new Vector3 (0, 90, 0));
				Vector3 v = transform.position;
				v.z -= 3;
				transform.position = v;
				rotation = 1;
			} else if (rotation == 1) {
				transform.Rotate (new Vector3 (0, 90, 0));
				Vector3 v = transform.position;
				v.x -= 3;
				transform.position = v;
				rotation = 2;
			} else if (rotation == 2) {
				transform.Rotate (new Vector3 (0, 90, 0));
				Vector3 v = transform.position;
				v.z += 3;
				transform.position = v;
				rotation = 3;
			} else if (rotation == 3) {
				transform.Rotate (new Vector3 (0, 90, 0));
				Vector3 v = transform.position;
				v.x += 3;
				transform.position = v;
				rotation = 0;
			}
		}
	}
}
