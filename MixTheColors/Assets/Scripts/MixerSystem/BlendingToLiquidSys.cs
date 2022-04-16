using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using System;
using LevelChangeSys;
using MixerAddSystem;
using EndGameSys;

namespace BlendingSys
{
    public class BlendingToLiquidSys : MonoBehaviour
    { 
        public Material liquidMat;

        private Renderer liquidRenderer;

        private int liquidMatCount;

        private float fillValue = 1f;

        public float fillingSpeed = 100;

        private float greenColorPercentage = 0, redColorPercentage = 0, yellowColorPercentage = 0, navyblueColorPercentage = 0; 

        private Color currentBrightColor, currentDarkColor, correctBrightColor, correctDarkColor;

        private bool isPercentageCorrected = false;
        private void OnEnable()
        {
            BlendTheMixture.BlendAction += ColorPercentageCounter;
            CustomerDrinkAnim.CustomerEndDrinkAction += OnEndGameClear;
        }

        private void ColorPercentageCounter()
        {
            liquidMatCount = LevelChangeSystem.LCSinstance.levelCounter;
            liquidRenderer = GetComponent<Renderer>();

            float fPercentage = IngredientsPercentageCounter.IPCinstance.firstIngredientCurrentPercentage,
                sPercentage = IngredientsPercentageCounter.IPCinstance.secondIngredientCurrentPercentage,
                tPercentage = IngredientsPercentageCounter.IPCinstance.thirdIngredientCurrentPercentage;

            if (fPercentage < .01f && fPercentage != 0 
                && sPercentage < .01f && sPercentage != 0
                && tPercentage < .01f && tPercentage != 0)
            {
                fPercentage = sPercentage = tPercentage = 0;
                isPercentageCorrected = true;
            }

            greenColorPercentage = fPercentage; //green 

            switch (liquidMatCount)
            {
                case 0:
                    yellowColorPercentage = sPercentage; //yellow
                    break;
                case 1:
                    yellowColorPercentage = sPercentage; // red
                    redColorPercentage = tPercentage; //yellow
                    break;
                case 2:
                    redColorPercentage = sPercentage; // red
                    navyblueColorPercentage = tPercentage; //blue
                    break;
            }

            MatColorChange();
        }

        private void MatColorChange()
        {
            correctBrightColor = LevelChangeSystem.LCSinstance.brightColor;
            correctDarkColor = LevelChangeSystem.LCSinstance.darkColor;

            float rBrComp = 1 - Math.Abs(1 - (redColorPercentage + yellowColorPercentage ) / 100 - correctBrightColor.r); 
            float rDrComp = 1 - Math.Abs(1 - (redColorPercentage + yellowColorPercentage ) / 100 - correctDarkColor.r);

            float gBrComp = 1 - Math.Abs(1 - (greenColorPercentage + yellowColorPercentage )/ 100 - correctBrightColor.g);
            float gDrComp = 1 - Math.Abs(1 - (greenColorPercentage + yellowColorPercentage ) / 100 - correctDarkColor.g);

            float bBrComp = 1 - Math.Abs(1 - navyblueColorPercentage / 100 - correctBrightColor.b);
            float bDrComp = 1 - Math.Abs(1 - navyblueColorPercentage / 100 - correctDarkColor.b);

            currentBrightColor = new Color(rBrComp, gBrComp, bBrComp);
            currentDarkColor = new Color(rDrComp, gDrComp, bDrComp);

            if (redColorPercentage == 0 && greenColorPercentage == 0 && navyblueColorPercentage == 0 && yellowColorPercentage == 0 && !isPercentageCorrected)
            {
                currentBrightColor = Color.clear;
                currentDarkColor = Color.clear;

                fillValue = 0;
            }

            FillTheBlenderByTheLiquid();
        }

        private void FillTheBlenderByTheLiquid()
        {

            liquidRenderer.material = liquidMat;

            /* liquidRenderer.material.SetColor("TheSideColor", currentDarkColor);
             liquidRenderer.material.SetColor("TheTopColor", currentBrightColor);*/

            liquidMat.SetColor("TheTopColor", currentBrightColor);
            liquidMat.SetColor("TheSideColor", currentDarkColor);

            liquidMat.SetFloat("TheFillValue", fillValue);
        }

        private void OnEndGameClear()
        {
            liquidRenderer.material = liquidMat;

            liquidMat.SetColor("TheTopColor", Color.clear);
            liquidMat.SetColor("TheSideColor", Color.clear);

            liquidMat.SetFloat("TheFillValue", 0);
        }

        private void OnDisable()
        {
            BlendTheMixture.BlendAction -= ColorPercentageCounter;
            CustomerDrinkAnim.CustomerEndDrinkAction -= OnEndGameClear;
        }
    }
}
