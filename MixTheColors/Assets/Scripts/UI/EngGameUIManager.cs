using MixerAddSystem;
using UnityEngine;
using EndGameSys;
using TMPro;

namespace UI
{
    public class EngGameUIManager : MonoBehaviour
    {
        public GameObject EndGameUIMenu;

        public TMP_Text scoreText;

        private void OnEnable()
        {
            CustomerDrinkAnim.CustomerEndDrinkAction += EngGameUISetUp;
        }

        private void EngGameUISetUp()
        {
            EndGameUIMenu.SetActive(true);

            int scoreTextNum = Mathf.Abs((int)IngredientsPercentageCounter.IPCinstance.levelPercentage);

            scoreText.text = scoreTextNum.ToString();
        }

        private void OnDisable()
        {
            CustomerDrinkAnim.CustomerEndDrinkAction -= EngGameUISetUp;
        }
    }
}