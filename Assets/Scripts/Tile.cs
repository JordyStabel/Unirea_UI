using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour {

    MapManager mapManager;

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
        Debug.Log(this.GetComponent<Image>().name);
    }
}