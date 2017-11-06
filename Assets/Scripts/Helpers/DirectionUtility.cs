using System;
using UnityEngine;

public class DirectionUtility {

	public static readonly Direction[] directionArray = { Direction.NORTH, Direction.NORTH_EAST, Direction.EAST, Direction.SOUTH_EAST, Direction.SOUTH, Direction.SOUTH_WEST,
		Direction.WEST, Direction.NORTH_WEST };

	public static Direction GetDirectionOfPos(Vector2Int current, Vector2Int test) {
		if (current == test)
			return Direction.NONE;

		int curX = current.x;
		int curY = current.y;

		int testX = test.x;
		int testY = test.y;

		if (testX == curX && testY == curY  + 1) {
			return Direction.NORTH;
		} else if (testX == curX + 1 && testY == curY) {
			return Direction.EAST;
		} else if (testX == curX && testY == curY - 1) {
			return Direction.SOUTH;
		} else if (testX == curX - 1 && testY == curY) {
			return Direction.WEST;
		} else {
			return Direction.NONE;
		}
	}

	public static Direction Rotate90 (Direction current) {
		switch (current) {
		case Direction.NORTH:
			return Direction.EAST;
		case Direction.EAST:
			return Direction.SOUTH;
		case Direction.SOUTH:
			return Direction.WEST;
		case Direction.WEST:
			return Direction.NORTH;
		default:
			return Direction.NONE;
		}
	}

}
