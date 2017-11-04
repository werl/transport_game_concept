using System;
using UnityEngine;

public class MessageWay : MessageTile {
	
	public Vector2Int position;
	public WayType wayType;
	public PathType pathType;

	public MessageWay (TileBase sender, Vector2Int position, TileType tileType, Direction direction, WayType wayType, PathType pathType) : base(sender, tileType, direction) {
		this.position = position;
		this.wayType = wayType;
		this.pathType = pathType;
	}
}
