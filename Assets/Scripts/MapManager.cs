using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour {

    public static MapManager instance;

    public MapInfo_UI mapInfo_UI;

    public GameObject tile;
    public Sprite[] sprites;
    public Sprite townSprite;
    public GridLayoutGroup content;

    public int maxWidth;
    public int maxHeight;

    private GameObject[,] tileArray;

    private List<Vector2> townList = new List<Vector2>();

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build managers in the scene");
        }
        instance = this;
    }

    void Start()
    {
        tileArray = new GameObject[maxWidth, maxHeight];

        townList.Add(new Vector2(1, 4));
        townList.Add(new Vector2(3, 14));
        townList.Add(new Vector2(7, 7));

        GenerateMap();
    }

    private void GenerateMap()
    {
        for (int x = 0; x < maxHeight; x++)
        {
            for (int y = 0; y < maxWidth; y++)
            {
                GameObject _tile = Instantiate(tile, content.transform);
                _tile.name = "[" + x + "][" + y + "]";
                tileArray[x, y] = _tile;
                int arrayIndex = UnityEngine.Random.Range(0, sprites.Length);
                Sprite sprite = sprites[arrayIndex];
                _tile.GetComponent<Image>().sprite = sprite;
            }
        }

        foreach (Vector2 coordinate in townList)
        {
            tileArray[Convert.ToInt32(coordinate.x), Convert.ToInt32(coordinate.y)].GetComponent<Image>().sprite = townSprite;
        }
    }

    public void SelectTown(Tile tile)
    {
        mapInfo_UI.Show(tile);
    }
}