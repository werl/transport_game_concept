using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public GameObject grass;
	public GameObject road;
	public GameObject road_T;
	public GameObject road_X;
	public GameObject road_Turn;

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
		switch (type) {
		case 0:
			ChangeTileInternal (road, 1);
			break;
		case 1:
			ChangeTileInternal (road_T, 2);
			break;
		case 2:
			ChangeTileInternal (road_X, 3);
			break;
		case 3:
			ChangeTileInternal (road_Turn, 4);
			break;
		case 4:
			ChangeTileInternal (grass, 0);
			break;
		default:
			Debug.Log (string.Format ("Tile type {0} is not implemented", type));
			break;
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
		switch (type) {
		case 1:
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
			break;
		case 2:
		case 4:
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
			break;
		default:
			//NOOP
			break;
		}
	}
}
