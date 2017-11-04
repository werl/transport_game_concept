using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRoad : TileBase {
	
	public GameObject straight;
	public GameObject curve_90;
	public GameObject intersection_T;
	public GameObject intersection_X;

	protected PathType pathType;
	protected WayType wayType = WayType.ROAD;


	protected override void StartInternal ()
	{
		GameObject.Instantiate (straight, transform, false);
		pathType = PathType.STRAIGHT;
	}

	protected override void UpdateInternal ()
	{

	}

	public override bool CanEnterTile (Direction dir) {
		switch (pathType) {
		case PathType.STRAIGHT:
			if ((direction == Direction.NORTH || direction == Direction.SOUTH) && (dir == Direction.NORTH || dir == Direction.SOUTH))
				return true;
			else if ((direction == Direction.EAST || direction == Direction.WEST) && (dir == Direction.EAST || dir == Direction.WEST))
				return true;
			else
				return false;
		case PathType.CURVE_90:
			switch (direction) {
			case Direction.NORTH:
				if (dir == Direction.NORTH || dir == Direction.WEST)
					return true;
				else
					return false;
			case Direction.EAST:
				if (dir == Direction.NORTH || dir == Direction.EAST)
					return true;
				else
					return false;
			case Direction.SOUTH:
				if (dir == Direction.SOUTH || dir == Direction.EAST)
					return true;
				else
					return false;
			case Direction.WEST:
				if (dir == Direction.SOUTH || dir == Direction.WEST)
					return true;
				else
					return false;
			}
			break;
		case PathType.INTERSECTION_T:
			switch (direction) {
			case Direction.NORTH:
				if (dir == Direction.NORTH || dir == Direction.EAST || dir == Direction.WEST)
					return true;
				else
					return false;
			case Direction.EAST:
				if (dir == Direction.NORTH || dir == Direction.SOUTH || dir == Direction.EAST)
					return true;
				else
					return false;
			case Direction.SOUTH:
				if (dir == Direction.EAST || dir == Direction.WEST || dir == Direction.SOUTH)
					return true;
				else
					return false;
			case Direction.WEST:
				if (dir == Direction.NORTH || dir == Direction.SOUTH || dir == Direction.WEST)
					return true;
				else
					return false;
			}
			break;
		case PathType.INTERSECTION_X:
			return true;
		default:
			return false;
		}

		return false;
	}

	public override void OnNeighbourChanged (TileBase changedTile) {
		if (changedTile != null && changedTile is TileRoad) {
			TileRoad neighbour = (TileRoad)changedTile;
			Vector2Int position = neighbour.pos;

			Direction dirOfTile = TileUtility.DirectionOfTile (pos, position);
			switch (dirOfTile) {
			case Direction.EAST:
			case Direction.WEST:
				RotateTo (Direction.EAST);
				break;
			default:
				break;
			}
		}
	}
}
