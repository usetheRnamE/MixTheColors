using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelChangeSys;
using MixerAddSystem;
using UnityEngine.UI;

namespace UI
{
    public class IngredientsButtonSpriteChange : MonoBehaviour
    {
        public int buttonIndex;

        private Image spriteRen;  

        private void OnEnable()
        {
            LevelChangeSystem.ChangeLevelAction += SpriteChange;
        }

        private void Awake()
        {
            spriteRen = GetComponent<Image>();
        }

        private void SpriteChange()
        {         
            int spriteIndex = LevelChangeSystem.LCSinstance.ingredientIndex[buttonIndex]; // gets specific sprite index for current button

            if (spriteIndex < 0)
            {
                this.gameObject.SetActive(false); // here I use -1 in LevelChangeSystem array to identify if this button has an appropriate sprite 
                return;
            }

            spriteRen.sprite = MixerIngredientManager.MIMinstance.ingredientSprites[spriteIndex]; // sets sprite by the following index
        }

        private void OnDisable()
        {
            LevelChangeSystem.ChangeLevelAction -= SpriteChange;
        }
    }
}
