using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRoad : TileBase {
	
	public GameObject straight;
	public GameObject curve_90;
	public GameObject intersection_T;
	public GameObject intersection_X;
	public GameObject single;

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

	public void ChangePathType(PathType type) {
		switch (type) {
		case PathType.STRAIGHT:
			ChangePathTypeInternal (straight);
			pathType = PathType.STRAIGHT;
			break;
		case PathType.CURVE_90:
			ChangePathTypeInternal (curve_90);
			pathType = PathType.CURVE_90;
			break;
		case PathType.INTERSECTION_T:
			ChangePathTypeInternal (intersection_T);
			pathType = PathType.INTERSECTION_T;
			break;
		case PathType.INTERSECTION_X:
			ChangePathTypeInternal (intersection_X);
			pathType = PathType.INTERSECTION_X;
			break;
		case PathType.SINGLE:
			ChangePathTypeInternal (single);
			pathType = PathType.SINGLE;
			break;
		default:
			break;
		}
	}

	private void ChangePathTypeInternal (GameObject obj) {
		GameObject.Destroy (transform.GetChild (0).gameObject);
		GameObject.Instantiate (obj, transform, false);
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
		case PathType.SINGLE:
			switch (direction) {
			case Direction.NORTH:
				if (dir == Direction.NORTH)
					return true;
				break;
			case Direction.EAST:
				if (dir == Direction.EAST)
					return true;
				break;
			case Direction.SOUTH:
				if (dir == Direction.SOUTH)
					return true;
				break;
			case Direction.WEST:
				if (dir == Direction.WEST)
					return true;
				break;
			default:
				return false;
				break;
			}
			break;
		default:
			return false;
			break;
		}

		return false;
	}

	public override void OnNeighbourChanged () {
		WorldCreator creator = GameObject.FindObjectOfType<WorldCreator> ();

		TileHolder thNorth = creator.GetTileForPosition (TileUtility.GetNorthV2 (pos));
		TileHolder thEast = creator.GetTileForPosition (TileUtility.GetEastV2 (pos));
		TileHolder thSouth = creator.GetTileForPosition (TileUtility.GetSouthV2 (pos));
		TileHolder thWest = creator.GetTileForPosition (TileUtility.GetWestV2 (pos));

		bool bNorth = thNorth?.GetCurrentTile() is TileRoad;
		bool bEast = thEast?.GetCurrentTile() is TileRoad;
		bool bSouth = thSouth?.GetCurrentTile() is TileRoad;
		bool bWest = thWest?.GetCurrentTile() is TileRoad;

		if (bNorth) {
			if (bSouth) {
				if (bWest) {
					if (bEast) {
						ChangePathType (PathType.INTERSECTION_X);
						RotateTo (Direction.NORTH, false);
					} else {
						ChangePathType (PathType.INTERSECTION_T);
						RotateTo (Direction.SOUTH, false);
					}
				} else if (bEast) {
					ChangePathType (PathType.INTERSECTION_T);
					RotateTo (Direction.NORTH, false);
				} else {
					ChangePathType (PathType.STRAIGHT);
					RotateTo (Direction.NORTH, false);
				}
			} else if (bEast) {
				if (bWest) {
					ChangePathType (PathType.INTERSECTION_T);
					RotateTo (Direction.WEST, false);
				} else {
					ChangePathType (PathType.CURVE_90);
					RotateTo (Direction.NORTH, false);
				}
			} else if (bWest) {
				ChangePathType (PathType.CURVE_90);
				RotateTo (Direction.WEST, false);
			} else {
				ChangePathType (PathType.SINGLE);
				RotateTo (Direction.NORTH, false);
			}
		} else if (bSouth) {
			if (bEast) {
				if (bWest) {
					ChangePathType (PathType.INTERSECTION_T);
					RotateTo (Direction.EAST, false);
				} else {
					ChangePathType (PathType.CURVE_90);
					RotateTo (Direction.EAST, false);
				}
			} else if (bWest) {
				ChangePathType (PathType.CURVE_90);
				RotateTo (Direction.SOUTH, false);
			} else {
				ChangePathType (PathType.SINGLE);
				RotateTo (Direction.SOUTH, false);
			}
		} else if (bEast) {
			if (bWest) {
				ChangePathType (PathType.STRAIGHT);
				RotateTo (Direction.EAST, false);
			} else {
				ChangePathType (PathType.SINGLE);
				RotateTo (Direction.EAST, false);
			}
		} else if (bWest) {
			ChangePathType (PathType.SINGLE);
			RotateTo (Direction.WEST, false);
		}
	}
}
