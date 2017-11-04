using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTile {

	public TileBase sender;
	public TileType tileType;
	public Direction direction;

	public MessageTile(TileBase sender, TileType tileType, Direction direction) {
		this.sender = sender;
		this.tileType = tileType;
		this.direction = direction;
	}

}
