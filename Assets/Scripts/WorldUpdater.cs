using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUpdater : MonoBehaviour {

	private Queue<TileHolder> tilesToUpdate = new Queue<TileHolder>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		if (tilesToUpdate.Count > 0)
			FixedUpdateTiles ();
	}

	private void FixedUpdateTiles() {
		while (tilesToUpdate.Count > 0) {
			TileHolder th = tilesToUpdate.Dequeue ();
			th.SetUpdateState (UpdateState.STARTED);
			th.GetCurrentTile ().OnNeighbourChanged (th.GetUpdateInitiator());
			th.FinishUpdate ();
			th.SetUpdateState (UpdateState.FINISHED);
		}
	}

	public void QueueTileForUpdate(TileHolder tileHloder) {
		tilesToUpdate.Enqueue (tileHloder);
	}
}
