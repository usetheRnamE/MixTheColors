using UI;
using UnityEngine;
using MixerAddSystem;
using System;

namespace EndGameSys
{
    public class CameraSlide : MonoBehaviour
    {
        private Animator cameraAnim;

        public static event Action CameraEndSlideAction;

        private void OnEnable()
        {
            BlenderAnimationController.BlendFinishAction += SlideTheCameraLeft;
            ReplayTheGame.ReloadTheGame += SlideTheCameraRight;
        }

        private void Awake()
        {
            cameraAnim = GetComponent<Animator>();
        }

        private void SlideTheCameraLeft()
        {
            cameraAnim.SetBool("IsSlide", true);
        }

        private void SlideTheCameraRight()
        {
            cameraAnim.SetBool("IsSlide", false);
        }

        public void OnCameraSlideEnd()
        {
            CameraEndSlideAction?.Invoke();
        }

        private void OnDisable()
        {
            BlenderAnimationController.BlendFinishAction -= SlideTheCameraLeft;
            ReplayTheGame.ReloadTheGame -= SlideTheCameraRight;
        }
    }
}