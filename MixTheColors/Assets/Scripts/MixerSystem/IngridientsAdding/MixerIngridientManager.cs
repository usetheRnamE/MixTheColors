using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixerAddSystem
{
    public class MixerIngridientManager : MonoBehaviour
    {
        public GameObject[] ingredients;

        public Sprite[] ingredientSprites;

        public Transform spawnPoint;

        public Animator mixerCoverAnimator;

        private float delay = 1f;

        private void OnEnable()
        {
              MixerCoverEventManager.CoverOpenAction += SpawnTheIngrediet;
        }

        private void SpawnTheIngrediet() { Instantiate(ingredients[0], spawnPoint.position, Quaternion.identity); }

        public void OnButtonClick() { StartCoroutine(StartMixerCoverAnim()); }

        private IEnumerator StartMixerCoverAnim()
        {
            mixerCoverAnimator.SetBool("IsIngredientAdd", true);

            yield return new WaitForSeconds(delay);

            mixerCoverAnimator.SetBool("IsIngredientAdd", false);
        }

        private void OnDisable()
        {
             MixerCoverEventManager.CoverOpenAction -= SpawnTheIngrediet;
        }
    }
}