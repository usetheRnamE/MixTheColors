using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixerAddSystem
{
    public class IngridientAnimatorDisable : MonoBehaviour
    {
        public void OnIngridientEndAnim() { Destroy(GetComponent<Animator>());  }
    }
}
