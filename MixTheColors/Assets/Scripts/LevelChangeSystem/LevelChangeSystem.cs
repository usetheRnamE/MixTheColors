using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LevelChangeSys
{
    public class LevelChangeSystem : MonoBehaviour
    {
        private  int levelCounter = 0;

        [HideInInspector]
        public int[] ingredientIndex;

        public static event Action ChangeLevelAction;

        public static LevelChangeSystem LCSinstance;

        public GameObject[] buttons;

        private void Awake()
        {
            LCSinstance = this;
        }

        private void Start()
        {
            ChangeLevel();
            //ButtonReset();
        }

        private void ChangeLevel()
        {
            switch (levelCounter)
            {
                case 0:
                    ingredientIndex = new int[] { 0, 1, -1 }; // -1 here means the null cuz index in an array cannot be less than zero
                    break;
                case 1:
                    ingredientIndex = new int[] { 0, 2, 3 };
                    break;
                case 2:
                    ingredientIndex = new int[] { 4, 5, 6 };
                    break;
                default:
                    levelCounter = 0;
                    ChangeLevel();
                    break;
            }

            ChangeLevelAction?.Invoke();
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
