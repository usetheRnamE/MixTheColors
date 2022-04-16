using System;
using UnityEngine;

namespace UI
{
    public class ReplayTheGame : MonoBehaviour
    {
        public static event Action ReloadTheGame;

        public void OnReplayTheGameButtonClick()
        {
            ReloadTheGame?.Invoke();
        }
    }
}
