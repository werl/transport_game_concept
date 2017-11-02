﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour {

	public int width = 10;
	public int length = 10;

	public GameObject tile;

	protected Dictionary<TileCoordinate, Tile> Tiles = new Dictionary<TileCoordinate, Tile>();

	void Start () {
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < length; j++) {
				GameObject o = GameObject.Instantiate (tile);
				o.name = "Tile " + i + ", " + j;
				o.transform.parent = transform;
				o.transform.SetPositionAndRotation (new Vector3 (i * 3, 0, j * 3), Quaternion.identity);

				Tiles.Add (new TileCoordinate (i, j), o.GetComponent<Tile>());
			}
		}
		tile.gameObject.SetActive (false);
	}
	
	void Update () {
		
	}
}