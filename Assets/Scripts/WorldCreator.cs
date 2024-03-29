﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour {

	public int width = 10;
	public int length = 10;

	private GameObject groundTilePrefab;
	private GameObject tileHolderPrefab;

	private Dictionary<Vector2Int, TileHolder> Tiles = new Dictionary<Vector2Int, TileHolder>();

	void Start () {
		groundTilePrefab = GameObject.FindObjectOfType<StaticTiles> ()?.grass;
		tileHolderPrefab = GameObject.FindObjectOfType<StaticTiles> ()?.TileHolder;

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < length; y++) {
				GameObject holder = GameObject.Instantiate (tileHolderPrefab, transform, false);
				holder.name = "Tile " + x + ", " + y;
				holder.transform.SetPositionAndRotation (new Vector3 (x * 3, 0, y * 3), Quaternion.identity);

				TileHolder t = holder.GetComponent<TileHolder> ();
				Vector2Int pos = new Vector2Int (x, y);
				t.SetPosition (pos);
				t.ChangeTileTo (groundTilePrefab, pos, false, false);

				Tiles.Add (pos, t);
			}
		}
	}

	public TileHolder GetTileForPosition (Vector2Int position) {
		TileHolder th = null;
		Tiles.TryGetValue (position, out th);
		return th;
	}

}
