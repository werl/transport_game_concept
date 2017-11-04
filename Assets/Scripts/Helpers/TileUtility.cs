using System;
using UnityEngine;

public class TileUtility
{
	public static Vector2Int[] GetTilesAround(Vector2Int position) {
		Vector2Int[] ret = new Vector2Int[8];

		ret [0] = GetNorthV2 (position);
		ret [1] = GetNorthEastV2 (position);
		ret [2] = GetEastV2 (position);
		ret [3] = GetSouthEastV2 (position);
		ret [4] = GetSouthV2 (position);
		ret [5] = GetSouthWestV2 (position);
		ret [6] = GetWestV2 (position);
		ret [7] = GetNorthWestV2 (position);

		return ret;
	}

	public static Vector2Int GetNorthV2(Vector2Int input) {
		return new Vector2Int (input.x, input.y + 1);
	}

	public static Vector2Int GetNorthEastV2(Vector2Int input) {
		return new Vector2Int (input.x - 1, input.y + 1);
	}

	public static Vector2Int GetEastV2(Vector2Int input) {
		return new Vector2Int (input.x - 1, input.y);
	}

	public static Vector2Int GetSouthEastV2(Vector2Int input) {
		return new Vector2Int (input.x - 1, input.y - 1);
	}

	public static Vector2Int GetSouthV2(Vector2Int input) {
		return new Vector2Int (input.x, input.y - 1);
	}

	public static Vector2Int GetSouthWestV2(Vector2Int input) {
		return new Vector2Int (input.x + 1, input.y - 1);
	}

	public static Vector2Int GetWestV2(Vector2Int input) {
		return new Vector2Int (input.x + 1, input.y);
	}

	public static Vector2Int GetNorthWestV2(Vector2Int input) {
		return new Vector2Int (input.x + 1, input.y + 1);
	}

	public static Direction DirectionOfTile(Vector2Int original, Vector2Int test) {
		Vector2Int north = GetNorthV2 (original);
		if (test == north)
			return Direction.NORTH;
		Vector2Int NEast = GetNorthEastV2 (original);
		if (test == NEast)
			return Direction.NORTH_EAST;
		Vector2Int SEast = GetSouthEastV2 (original);
		if (test == SEast)
			return Direction.SOUTH_EAST;
		Vector2Int south = GetSouthV2 (original);
		if (test == south)
			return Direction.SOUTH;
		Vector2Int SWest = GetSouthWestV2 (original);
		if (test == SWest)
			return Direction.SOUTH_WEST;
		Vector2Int west = GetWestV2 (original);
		if (test == west)
			return Direction.WEST;
		Vector2Int NWest = GetNorthWestV2 (original);
		if (test == NWest)
			return Direction.NORTH_WEST;
		return Direction.NONE;
	}

}
