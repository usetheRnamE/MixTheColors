using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixerAddSystem
{
    public class BlenderAnimationController : MonoBehaviour
    {
        private Animator blenderAnimator;

        private float delay = .2f;
        private void OnEnable()
        {
            IngredientAnimatorDisable.IngredientInMixerAction += OnImpact;
        }
        private void Start()
        {
            blenderAnimator = GetComponent<Animator>();
        }

        private void OnImpact()
        {
            StartCoroutine(StartImpactAnimation());
        }

        private IEnumerator StartImpactAnimation()
        {
            blenderAnimator.SetBool("IsImpact", true);

            yield return new WaitForSeconds(delay);

            blenderAnimator.SetBool("IsImpact", false);
        }
        private void OnDisable()
        {
            IngredientAnimatorDisable.IngredientInMixerAction -= OnImpact;
        }
    }
}
