using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour {

	public int width = 10;
	public int length = 10;

	private Dictionary<Vector2Int, TileHolder> Tiles = new Dictionary<Vector2Int, TileHolder>();

	void Start () {
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < length; j++) {
				GameObject holder = GameObject.Instantiate (GetTileHolderPrefab(), transform, false);
				holder.name = "Tile " + i + ", " + j;
				holder.transform.SetPositionAndRotation (new Vector3 (i * 3, 0, j * 3), Quaternion.identity);

				TileHolder t = holder.GetComponent<TileHolder> ();
				Vector2Int pos = new Vector2Int (i, j);
				t.SetPosition (pos);
				t.ChangeTileTo (GetGroundTilePrefab(), pos, false, false);

				Tiles.Add (pos, t);
			}
		}
	}
	
	void Update () {
		
	}

	public TileHolder GetTileForPosition(Vector2Int position) {
		TileHolder th = null;
		Tiles.TryGetValue (position, out th);
		return th;
	}

	private GameObject GetTileHolderPrefab() {
		GameObject o = GameObject.FindObjectOfType<StaticTiles> ()?.TileHolder;

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
