using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UI
{
    public class BlendTheMixture : MonoBehaviour
    {
        public static event Action BlendAction;

        public void OnBlenderButtonClick()
        {
            BlendAction?.Invoke();
        }
    }
}
