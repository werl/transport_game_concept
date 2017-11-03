using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrass : TileBase {

	public GameObject tile;

	protected override void StartInternal ()
	{
		GameObject.Instantiate (tile, transform, false);
	}

	protected override void UpdateInternal ()
	{
		
	}

	public override bool CanEnterTile (Direction dir) {
		return false;
	}
}
