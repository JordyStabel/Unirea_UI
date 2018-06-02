using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour {

    public GameObject tile;
    public Sprite[] sprites;
    public GridLayoutGroup content;

    private GameObject[,] tileArray = new GameObject[19, 19];

    private List<Vector2> townList = new List<Vector2>();

    void Start()
    {
        townList.Add(new Vector2(1, 4));
        townList.Add(new Vector2(3, 14));
        townList.Add(new Vector2(7, 7));

        GenerateMap();
    }

    private void GenerateMap()
    {
        for (int x = 0; x < 19; x++)
        {
            for (int y = 0; y < 19; y++)
            {
                GameObject _tile = Instantiate(tile, content.transform);
                _tile.name = "[" + x + "][" + y + "]";
                tileArray[x, y] = _tile;
                int arrayIndex = UnityEngine.Random.Range(0, sprites.Length - 1);
                Sprite sprite = sprites[arrayIndex];
                _tile.GetComponent<Image>().sprite = sprite;
            }
        }

        foreach (Vector2 coordinate in townList)
        {
            tileArray[Convert.ToInt32(coordinate.x), Convert.ToInt32(coordinate.y)].GetComponent<Image>().sprite = sprites[3]; // TODO: Make this dynamic
        }
    }
}