using UnityEngine;
using UnityEngine.UI;

public class MapInfo_UI : MonoBehaviour {

    public GameObject UI;
    public Text townName;

    private Tile tile;

	public void Show(Tile _tile)
    {
        tile = _tile;

        townName.text = _tile.name;

        UI.SetActive(true);
    }
	
    public void Hide()
    {
        UI.SetActive(false);
    }
}