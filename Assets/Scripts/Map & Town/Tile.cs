using UnityEngine;

namespace Unirea.UI
{
    public class Tile : MonoBehaviour
    {

        MapManager mapManager;

        public Vector2 coordinates;
        public int town_id;

        void Start()
        {
            mapManager = MapManager.instance;
        }

        public void TileClick()
        {
            mapManager.SelectTown(this);
        }
    }
}