using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRoad : TileBase {
	
	public GameObject straight;
	public GameObject curve_90;
	public GameObject intersection_T;
	public GameObject intersection_X;

	protected WayType wayType;


	protected override void StartInternal ()
	{
		GameObject.Instantiate (straight, transform, false);
	}

	protected override void UpdateInternal ()
	{

	}

	public override bool CanEnterTile (Direction dir) {
		return false;
	}
}
