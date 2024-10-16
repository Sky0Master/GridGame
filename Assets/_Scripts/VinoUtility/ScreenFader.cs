using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VinoUtility;

public class ScreenFader : MonoSingleton<ScreenFader>
{

    public CanvasGroup fadeCanvasGroup;
    
    public float fadeDuration;

    public void SetAlpha(float alphaValue)
    {
        fadeCanvasGroup.alpha = alphaValue;
    }

    //alpha: from 1 -> 0
    public IEnumerator FadeIn()
    {
        fadeCanvasGroup.gameObject.SetActive(false);
        yield return StartCoroutine(LerpUtility.Lerp(1f,0f,fadeDuration,SetAlpha));
    }
    
    //alpha: from 0 -> 1
    public IEnumerator FadeOut()
    {
        fadeCanvasGroup.gameObject.SetActive(true);
        yield return StartCoroutine(LerpUtility.Lerp(0f,1f,fadeDuration,SetAlpha));
    
    }
}
