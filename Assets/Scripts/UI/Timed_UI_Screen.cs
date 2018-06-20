using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Unirea.UI
{
    public class Timed_UI_Screen : UI_Screen
    {
        #region Varibles & Properties

        [Header("Properties")]
        public float waitTime = 2f;
        public UnityEvent onWaitCompleted = new UnityEvent();

        private float startTime;

        #endregion

        #region Methods

        public override void StartScreen()
        {
            base.StartScreen();

            startTime = Time.time;
            
        }

        public override void CloseScreen()
        {
            base.CloseScreen();
            StartCoroutine(WaitForTime());
        }

        IEnumerator WaitForTime()
        {
            yield return new WaitForSeconds(waitTime);

            if (onWaitCompleted != null)
            {
                onWaitCompleted.Invoke();
            }
        }

        #endregion
    }
}