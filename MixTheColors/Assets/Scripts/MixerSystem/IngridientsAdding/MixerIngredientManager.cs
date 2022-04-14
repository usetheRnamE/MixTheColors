using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelChangeSys;
using UI;
using UnityEngine.EventSystems;

namespace MixerAddSystem
{
    public class MixerIngredientManager : MonoBehaviour
    {
        public GameObject[] ingredients;

        public Sprite[] ingredientSprites;

        public Transform spawnPoint;

        public Animator mixerCoverAnimator;

        private float delay = 1f;

        private int currentButtonIndex;

        public static MixerIngredientManager MIMinstance;

        private void OnEnable()
        {
              MixerCoverEventManager.CoverOpenAction += SpawnTheIngrediet;
        }

        private void Awake()
        {
            MIMinstance = this;
        }

        private void SpawnTheIngrediet() 
        {
            int gmObjIndex = LevelChangeSystem.LCSinstance.ingredientIndex[currentButtonIndex];

            if (gmObjIndex < 0)
                return;

            Instantiate(ingredients[gmObjIndex], spawnPoint.position, Quaternion.identity); 
        }

        public void OnButtonClick()
        {
            currentButtonIndex = EventSystem.current.currentSelectedGameObject.GetComponent<IngredientsButtonSpriteChange>().buttonIndex;

            StartCoroutine(StartMixerCoverAnim()); 
        }

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