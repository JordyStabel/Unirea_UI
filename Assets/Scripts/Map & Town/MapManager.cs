using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Backend.Rest;
using Assets.Backend.RestModels;

namespace Unirea.UI
{
    public class MapManager : MonoBehaviour
    {
        public static MapManager instance;
        public Dropdown townSelector;
        public InputField townSearch;
        public MapInfo_UI mapInfo_UI;

        public GameObject tile;
        public Sprite[] sprites;
        public Sprite townSprite;
        public GridLayoutGroup content;
        public float snappingSpeed;

        public int maxWidth;
        public int maxHeight;

        private GameObject[,] tileArray;

        private List<Map> townList = new List<Map>();

        private ArmyRest armyRest = new ArmyRest();
        private MapRest mapRest = new MapRest();
        private Tile currentTile;

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
            townSearch.onValueChanged.AddListener(delegate { SearchTowns(townSearch.text); });
            townSelector.onValueChanged.AddListener(delegate { TownFromSelector(townSelector.options[townSelector.value].text); });
            GenerateMap();
        }

        void OnEnable()
        {
            EventManager.mapUpdateEvent += UpdateMap;
        }

        private void OnDisable()
        {
            EventManager.mapUpdateEvent -= UpdateMap;
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
        }

        public void SelectTown(Tile tile)
        {
            if (tile.name != null)
            {
                currentTile = tile;
                mapInfo_UI.Show(tile);
            }
            else
                mapInfo_UI.Hide();

            StopAllCoroutines();
            StartCoroutine(SnapToTown(tile.coordinates));
        }

        IEnumerator SnapToTown(Vector2 coordinates)
        {
            Vector3 targetPosition = new Vector3(((coordinates.x * 250) - 415) * -1, (coordinates.y * 250) - 835);

            while (Vector3.Distance(content.transform.localPosition, targetPosition) > 50f)
            {
                content.transform.localPosition = Vector3.Lerp(
                    content.GetComponent<RectTransform>().localPosition,
                    new Vector3(((coordinates.x * 250) - 415) * -1, (coordinates.y * 250) - 835),
                    Time.deltaTime * snappingSpeed);
                yield return null;
            }
        }

        public async void UpdateMap()
        {
            List<Map> map = await mapRest.GetAllTowns();
            townSelector.ClearOptions();
            foreach (Map town in map)
            {
                townList.Add(town);
                CreateTown(town);
            }
        }

        public void CreateTown(Map town)
        {
            tileArray[Convert.ToInt32(town.x), Convert.ToInt32(town.y)].GetComponent<Image>().sprite = townSprite;
            Tile newTown = tileArray[Convert.ToInt32(town.x), Convert.ToInt32(town.y)].GetComponent<Tile>();
            newTown.name = town.id.ToString();
            newTown.town_id = town.id;
            townSelector.options.Add(new Dropdown.OptionData(town.x + "," + town.y + "," + town.id));
        }

        public void SearchTowns(string input)
        {
            townSelector.ClearOptions();

            if (input != "")
            {
                foreach (Map town in townList)
                {
                    if (town.id.ToString().Contains(input))
                    {
                        townSelector.options.Add(new Dropdown.OptionData(town.x + "," + town.y + "," + town.id));
                    }
                }
            }
            else
            {
                foreach (Map town in townList)
                {
                    townSelector.options.Add(new Dropdown.OptionData(town.x + "," + town.y + "," + town.id));
                }
            }
        }

        public void TownFromSelector(string input)
        {
            int x = Int32.Parse(input.Split(',')[0]);
            int y = Int32.Parse(input.Split(',')[1]);
            StopAllCoroutines();
            StartCoroutine(SnapToTown(new Vector2(y, x)));
        }

        public async void AttackTown()
        {
            // TODO: Fix Troops and amount
            await armyRest.MoveArmy(PlayerInfo.currentPlayer.AuthenticationToken, null, Int32.Parse(tile.name.Split(',')[2]), 2, PlayerInfo.currrentTown.townId);
        }
    }
}