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

        private float firstIngredientLocalPercentage, secondIngredientLocalPercentage, thirdIngredientLocalPercentage; 

        private List<GameObject>[] ingredients = new List<GameObject>[ingredientsNum];

        private int[] ingredientCounts = new int[buttonNum];

        private int[] ingredientIndexes = new int[buttonNum];

        private float levelPercentage, secondLevelPercentage, thirdlevelPercentage;
        private float firstIngredientCurrentPercentage = 0, secondIngredientCurrentPercentage = 0, thirdIngredientCurrentPercentage = 0;

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
                PercentageCounter();
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

            if (ingredientIndexes[2] > 0) firstIngredientLocalPercentage = secondIngredientLocalPercentage = thirdIngredientLocalPercentage = 33.333f;
            else firstIngredientLocalPercentage = secondIngredientLocalPercentage = 50;

             if (ingredientCounts[0] > 0)
                    firstIngredientCurrentPercentage = Math.Abs(firstIngredientLocalPercentage - ((float)ingredientCounts[0] / (ingredientCounts[2] + ingredientCounts[1] + ingredientCounts[0]) * 100));

              if(ingredientCounts[1] > 0)
                    secondIngredientCurrentPercentage = Math.Abs(secondIngredientLocalPercentage - ((float)ingredientCounts[1] / (ingredientCounts[2] + ingredientCounts[1] + ingredientCounts[0]) * 100));

              if (ingredientCounts[2] > 0)
                   thirdIngredientCurrentPercentage = Math.Abs(thirdIngredientLocalPercentage - ((float)ingredientCounts[2] / (ingredientCounts[2] + ingredientCounts[1] + ingredientCounts[0]) * 100));

            levelPercentage = 100 - (firstIngredientCurrentPercentage + secondIngredientCurrentPercentage + thirdIngredientCurrentPercentage);

            if (levelPercentage >= 99.9)
                levelPercentage = 100;

            Debug.Log(levelPercentage + "%");
        }


      //  private void Per

        public void Mixing()
        {

        }
    }
}
