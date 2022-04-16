using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EndGameSys {
    public class CustomerDrinkAnim : MonoBehaviour
    {
        private Animator customerAnimator;

        public static event Action CustomerEndDrinkAction;

        private void OnEnable()
        {
            CameraSlide.CameraEndSlideAction += CustomerStartDrinking;
        }

        private void Awake()
        {
            customerAnimator = GetComponent<Animator>();
        }

        private void CustomerStartDrinking()
        {
            customerAnimator.SetBool("IsAllowedToDrink", true);
        }

        public void OnCustomerEndDrinking()
        {
            CustomerEndDrinkAction?.Invoke();

            customerAnimator.SetBool("IsAllowedToDrink", false);
        }

        private void OnDisable()
        {
            CameraSlide.CameraEndSlideAction -= CustomerStartDrinking;
        }
    }
}
