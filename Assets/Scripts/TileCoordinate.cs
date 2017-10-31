using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TileCoordinate {

	public readonly int x, y;

	public TileCoordinate(int x, int y){
		this.x = x;
		this.y = y;
	}

	public override bool Equals (object obj) {
		if (obj == null || GetType () != obj.GetType ())
			return false;
		TileCoordinate tc = (TileCoordinate)obj;
		return x == tc.x && y == tc.y;
	}

	public override int GetHashCode() 
	{
		return x ^ y;
	}

	public static bool operator ==(TileCoordinate tc1, TileCoordinate tc2) 
	{
		return tc1.x == tc2.x && tc1.y == tc2.y;
	}

	public static bool operator !=(TileCoordinate tc1, TileCoordinate tc2) 
	{
		return !(tc1 == tc2);
	}

}
