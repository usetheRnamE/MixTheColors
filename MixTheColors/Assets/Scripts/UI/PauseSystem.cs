using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PauseSystem : MonoBehaviour
    {
        private bool isPaused = false;
        public void OnPauseButtonClick()
        {
            Time.timeScale = isPaused ? 1 : 0;
            isPaused = !isPaused;
        }
    }
}
