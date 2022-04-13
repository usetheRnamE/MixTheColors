using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MixerAddSystem
{
    public class MixerCoverEventManager : MonoBehaviour
    {
        public static event Action CoverOpenAction;

        public void OnAnimationEvent()
        {
            CoverOpenAction?.Invoke();
        }
    }
}