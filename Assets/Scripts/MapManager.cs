using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Backend;
using Assets.Backend.Models;

public class MapManager : MonoBehaviour {

    public static MapManager instance;
    public MapInfo_UI mapInfo_UI;

    public GameObject tile;
    public Sprite[] sprites;
    public Sprite townSprite;
    public GridLayoutGroup content;
    public float snappingSpeed;

    public int maxWidth;
    public int maxHeight;

    private GameObject[,] tileArray;

    private List<Vector2> townList = new List<Vector2>();
    private List<Town> allTowns = new List<Town>();

    private UserManagement userManagement = new UserManagement();

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
                _tile.name = x + "," + y;
                _tile.GetComponentInChildren<Text>().text = x + "," + y;
                Tile tileScript = _tile.GetComponent<Tile>();
                tileScript.coordinates = new Vector2(y, x);
                tileArray[x, y] = _tile;
                int arrayIndex = UnityEngine.Random.Range(0, sprites.Length);
                Sprite sprite = sprites[arrayIndex];
                _tile.GetComponent<Image>().sprite = sprite;
            }
        }

        foreach (Vector2 coordinate in townList)
        {
            tileArray[Convert.ToInt32(coordinate.x), Convert.ToInt32(coordinate.y)].GetComponent<Image>().sprite = townSprite;
            Tile test = tileArray[Convert.ToInt32(coordinate.x), Convert.ToInt32(coordinate.y)].GetComponent<Tile>();
            test.name = "Henk " + coordinate;
        }
    }

    public void SelectTown(Tile tile)
    {
        if (tile.name.Contains("Henk"))
            mapInfo_UI.Show(tile);
        else
            mapInfo_UI.Hide();

        StopAllCoroutines();
        StartCoroutine(SnapToTown(tile.coordinates));
    }

    IEnumerator SnapToTown(Vector2 coordinates)
    {
        Vector3 targetPosition = new Vector3(((coordinates.x * 250) - 415) * -1, (coordinates.y * 250) -835);

        while (Vector3.Distance(content.transform.localPosition, targetPosition) > 50f)
        {
            content.transform.localPosition = Vector3.Lerp(
                content.GetComponent<RectTransform>().localPosition, 
                new Vector3(((coordinates.x * 250) - 415) * -1, (coordinates.y * 250) - 835), 
                Time.deltaTime * snappingSpeed);
            yield return null;
        }
    }

    public async void GetTowns()
    {
        string token = PlayerInfo.currentPlayer.AuthenticationToken;
        Debug.Log(token);

        allTowns = await userManagement.GetAllTowns(token);

        foreach (Town town in allTowns)
        {
            Debug.Log(town.Player);
        }
    }
}