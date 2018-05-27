using UnityEngine;
using Assets.Backend.Models;

namespace Unirea.UI
{
    public class EventManager : MonoBehaviour
    {
        public delegate void PlayerUpdateEvent();
        public static event PlayerUpdateEvent playerUpdateEvent;

        public static void PlayerUpdate()
        {
            if (playerUpdateEvent != null)
                playerUpdateEvent();
        }
    }
}