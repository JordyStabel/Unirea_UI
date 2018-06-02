using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour {

    MapManager mapManager;

    public Vector2 coordinates;

	// Use this for initialization
	void Start () {
        mapManager = MapManager.instance;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Test()
    {
        mapManager.SelectTown(this);
    }
}