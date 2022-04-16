using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using System;

namespace MixerAddSystem
{
    public class BlenderAnimationController : MonoBehaviour
    {
        private Animator blenderAnimator;

        private float impactDelay = .2f, blendingDelay = .5f;

        public static event Action BlendFinishAction;
        private void OnEnable()
        {
            IngredientAnimatorDisable.IngredientInMixerAction += OnImpact;
            BlendTheMixture.BlendAction += OnBlend;
        }
        private void Start()
        {
            blenderAnimator = GetComponent<Animator>();
        }

        private void OnImpact()
        {
            StartCoroutine(StartImpactAnimation());
        }
        private void OnBlend()
        {
            StartCoroutine(StartBlendingAnimation());
        }

        public void OnBlendFinish()
        {
            BlendFinishAction?.Invoke();
        }

        private IEnumerator StartImpactAnimation()
        {
            blenderAnimator.SetBool("IsImpact", true);

            yield return new WaitForSeconds(impactDelay);

            blenderAnimator.SetBool("IsImpact", false);
        }

        private IEnumerator StartBlendingAnimation()
        {
            blenderAnimator.SetBool("IsBlending", true);

            yield return new WaitForSeconds(blendingDelay);

            blenderAnimator.SetBool("IsBlending", false);
        }

        private void OnDisable()
        {
            IngredientAnimatorDisable.IngredientInMixerAction -= OnImpact;
            BlendTheMixture.BlendAction -= OnBlend; 
        }
    }
}
