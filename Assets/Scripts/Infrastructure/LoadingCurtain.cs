using System;
using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public class LoadingCurtain : MonoBehaviour
    {
        public CanvasGroup Curtain;

        private const float SpeedAlphaFade = 0.03f;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(FadiIn());
        }

        private IEnumerator FadiIn()
        {
            var waitSeconds = new WaitForSeconds(SpeedAlphaFade);
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= SpeedAlphaFade;
                yield return waitSeconds;
            }

            gameObject.SetActive(false);
        }
    }
}