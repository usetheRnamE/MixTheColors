using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class ApplicationQuiter : MonoBehaviour
    {
        public void OnQuitButtonClick()
        {
            Application.Quit();
        }
    }
}
