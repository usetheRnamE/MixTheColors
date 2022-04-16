using UI;
using UnityEngine;
using System;
using MixerAddSystem;

namespace LevelChangeSys
{
    public class LevelChangeSystem : MonoBehaviour
    {
       [HideInInspector]
        public  int levelCounter = 0;

        [HideInInspector]
        public int[] ingredientIndex;

        public static event Action ChangeLevelAction;

        public static LevelChangeSystem LCSinstance;

        public GameObject[] buttons;

        [HideInInspector]
        public Color brightColor, darkColor;

        private void OnEnable()
        {
            ReplayTheGame.ReloadTheGame += ChangeLevel;
        }

        private void Awake()
        {
            LCSinstance = this;
        }

        private void Start()
        {
            ChangeLevel();
          //  ButtonReset();
        }

        private void ChangeLevel()
        {
            
            float levelPercent = IngredientsPercentageCounter.IPCinstance.levelPercentage;
            if (levelPercent >= 90)
                levelCounter++;

            if (levelCounter > 2)
                levelCounter = 0;

            switch (levelCounter)
            {
                case 0:
                    ingredientIndex = new int[] { 0, 1, -1 }; // -1 here means the null cuz index in an array cannot be less than zero

                    brightColor = new Color(.68f, .37f, .01f);
                    darkColor = new Color(.75f, .61f, .01f);
                    break;
                case 1:
                    ingredientIndex = new int[] { 0, 2, 3 };

                    brightColor = new Color(.28f, .51f, .01f);
                    darkColor = new Color(.20f, .55f, .01f);
                    break;
                case 2:
                    ingredientIndex = new int[] { 5, 4, 6 };

                    brightColor = new Color(.20f, .04f, .04f);
                    darkColor = new Color(.20f, .02f, .02f);
                    break;               
            }

            ButtonReset();
            ChangeLevelAction?.Invoke();
        }

        private void OnDisable()
        {
            ReplayTheGame.ReloadTheGame += ChangeLevel;
        }

        private void ButtonReset()
        {
            foreach (var button in buttons)
            {
                button.SetActive(true);
            }
        }
    }
}
