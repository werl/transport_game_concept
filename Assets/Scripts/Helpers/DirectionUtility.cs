﻿using System;
using UnityEngine;

public class DirectionUtility {

	public static Direction GetDirectionFromPos(Vector2Int current, Vector2Int test) {
		if (current == test)
			return Direction.NONE;

		int curX = current.x;
		int curY = current.y;

		int testX = test.x;
		int testY = test.y;

		if (testX == curX + 1 && testY == curY) {
			return Direction.WEST;
		} else if (testX == curX - 1 && testY == curY) {
			return Direction.EAST;
		} else if (testX == curX && testY == curY + 1) {
			return Direction.NORTH;
		} else if (testX == curX && testY == curY - 1) {
			return Direction.SOUTH;
		} else {
			return Direction.NONE;
		}
	}

}