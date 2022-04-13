using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixerSystem
{
    public class IngredientsDataBase : MonoBehaviour
    {
        public GameObject[] ingredients;

        public Sprite[] ingredientSprites;

        [HideInInspector]
        public IngredientsDataBase IDBinstance;

        private void OnEnable()
        {
            IDBinstance = this; 
        }
    }
}