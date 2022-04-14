using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MixerAddSystem
{
    public class IngredientAnimatorDisable : MonoBehaviour
    {
        public static event Action IngredientInMixerAction;

        public void OnIngridientEndAnim()
        {
            Destroy(GetComponent<Animator>());

            IngredientInMixerAction?.Invoke();
        }
    }
}
