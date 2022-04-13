using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixerSystem
{
    public class AddTheIngredients : MonoBehaviour
    {
        public GameObject[] ingredients;

        public Transform spawnPoint;

        private int ingredientIndex;
        public void OnIngredientClick()
        {
            Instantiate(ingredients[0], spawnPoint);
        }
    }
}