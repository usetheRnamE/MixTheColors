using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelChangeSys;

namespace MixerAddSystem
{
    public class IngredientsPercentageCounter : MonoBehaviour
    {
        private const int ingredientsNum = 7, buttonNum = 3;

        private int proportionValue = 2;

        private List<GameObject>[] ingredients = new List<GameObject>[ingredientsNum];

        private int[] ingredientCounts = new int[buttonNum];

        private int[] ingredientIndexes = new int[buttonNum];

        private double firstLevelPercentage, secondLevelPercentage, thirdlevelPercentage;

        public Animator blenderAnimator;

        private void Awake()
        {
            for (int i = 0; i < 7; i++)
            {
                ingredients[i] = new List<GameObject>();
            }


        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Ingredient")
            {
              switch (other.gameObject.name)
                {
                    case "green apple(Clone)":
                        ingredients[0].Add(other.gameObject);
                        break;
                    case "banana(Clone)":
                        ingredients[1].Add(other.gameObject);
                        break;
                    case "orange(Clone)":
                        ingredients[2].Add(other.gameObject);
                        break;
                    case "cheries(Clone)":
                        ingredients[3].Add(other.gameObject);
                        break;
                    case "tomato(Clone)":
                        ingredients[4].Add(other.gameObject);
                        break;
                    case "cucumber(Clone)":
                        ingredients[5].Add(other.gameObject);
                        break;
                    case "eggplant(Clone)":
                        ingredients[6].Add(other.gameObject);
                        break;
                }
                //PercentageCounter();
            }
        }
        private void PercentageCounter()
        {
            ingredientIndexes = LevelChangeSystem.LCSinstance.ingredientIndex;

            for (int i = 0; i < ingredientIndexes.Length; i++)
            {
                if (ingredientIndexes[i] < 0) break;

                ingredientCounts[i] = ingredients[ingredientIndexes[i]].Count;
            }

            int numOfLevel = LevelChangeSystem.LCSinstance.levelCounter;

            switch (numOfLevel)
            {
                case 0:
                    if ((float) ingredientCounts[0] / ingredientCounts[1] == proportionValue)
                        firstLevelPercentage = 100;
                    else firstLevelPercentage = Math.Abs(proportionValue - (float) ingredientCounts[0] / ingredientCounts[1]) * 100;
                    break;
                case 1:
                    secondLevelPercentage = (double) ingredientCounts[0] / (ingredientCounts[2] + ingredientCounts[1] + ingredientCounts[0]) * 4 * 100;
                    break;
                case 2:
                    thirdlevelPercentage = (double) ingredientCounts[0] / (ingredientCounts[2] + ingredientCounts[1] + ingredientCounts[0]) * 2 * 100;
                    break;
            }
            Debug.Log(firstLevelPercentage + "%");
        }

        public void Mixing()
        {

        }
    }
}
