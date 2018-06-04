using UnityEngine;

public class Tile : MonoBehaviour {

    MapManager mapManager;

    public Vector2 coordinates;

	void Start () {
        mapManager = MapManager.instance;
	}

    public void TileClick()
    {
        mapManager.SelectTown(this);
    }
}