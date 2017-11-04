using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : MonoBehaviour {

	private TileBase updateInitiator;

	private TileBase currentTile;
	private Vector2Int position;

	private UpdateState uState = UpdateState.FINISHED;

	public void ChangeTileTo(GameObject nTile, Vector2Int pos, bool destroy = true, bool sendUpdate = true) {
		if (destroy) {
			GameObject.Destroy (transform.GetChild (0).gameObject);
		}

		currentTile = GameObject.Instantiate (nTile, transform, false).GetComponent<TileBase> ();
		currentTile.SetPosition (pos);

		if (sendUpdate) {
			currentTile.ChangeNeighbour ();
			SendToUpdateQueue (currentTile);
		}
	}

	public void SendToUpdateQueue(TileBase initiator) {
		if (uState == UpdateState.FINISHED) {
			updateInitiator = initiator;
			GameObject.FindObjectOfType<WorldUpdater> ()?.QueueTileForUpdate (this);
			uState = UpdateState.QUEUED;
		}
	}

	public TileBase GetUpdateInitiator() {
		return updateInitiator;
	}

	public void FinishUpdate() {
		updateInitiator = null;
	}

	public TileBase GetCurrentTile() {
		return currentTile;
	}

	public void SetPosition(Vector2Int pos) {
		this.position = pos;
	}

	public Vector2Int GetPosition() {
		return position;
	}

	public UpdateState GetUpdateState() {
		return uState;
	}

	public void SetUpdateState(UpdateState state) {
		uState = state;
	}
}
