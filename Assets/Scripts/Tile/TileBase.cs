using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileBase : MonoBehaviour {

	protected Vector2Int pos;
	[SerializeField]
	protected Direction direction;

	void Start () {
		StartInternal ();
	}

	protected abstract void StartInternal ();

	void Update() {
		UpdateInternal ();
	}

	protected abstract void UpdateInternal ();

	public Direction GetDirection() {
		return direction;
	}

	public void SetPosition(Vector2Int pos) {
		this.pos = pos;
	}

	public Vector2Int GetPosition() {
		return pos;
	}

	public void RotateNorth (bool update = true) {
		int numRotate = 0;

		switch(direction) {
		case Direction.NORTH:
			direction = Direction.NORTH;
			return;
		case Direction.EAST:
			direction = Direction.EAST;
			numRotate = 3;
			break;
		case Direction.SOUTH:
			direction = Direction.SOUTH;
			numRotate = 2;
			break;
		case Direction.WEST:
			direction = Direction.WEST;
			numRotate = 1;
			break;
		default:
			Debug.LogError ("Direction not implemented");
			break;
		}

		transform.Rotate (new Vector3 (0, numRotate * 90, 0));
		if (update)
			ChangeNeighbour ();
	}

	public void RotateTo (Direction dir, bool update = true) {
		int numRotate = 0;
		RotateNorth (update);

		switch (dir) {
		case Direction.NORTH:
			direction = Direction.NORTH;
			numRotate = 0;
			break;
		case Direction.EAST:
			direction = Direction.EAST;
			numRotate = 1;
			break;	
		case Direction.SOUTH:
			direction = Direction.SOUTH;
			numRotate = 2;
			break;
		case Direction.WEST:
			direction = Direction.WEST;
			numRotate = 3;
			break;
		default:
			Debug.LogError ("Direction not implemented");
			break;
		}
		
		transform.Rotate (new Vector3 (0, numRotate * 90, 0));
		if (update)
			ChangeNeighbour ();
	}

	public abstract bool CanEnterTile (Direction dir);

	public abstract void OnNeighbourChanged();

	public void ChangeNeighbour() {
		WorldCreator creator = GameObject.FindObjectOfType<WorldCreator> ();

		Vector2Int[] vector2 = TileUtility.GetTilesAround (pos);

		foreach (Vector2Int v2 in vector2) {
			creator.GetTileForPosition (v2)?.SendToUpdateQueue (this);
		}

		creator.GetTileForPosition (this.pos).SendToUpdateQueue (this);
	}

}
