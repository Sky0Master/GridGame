using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageFadeOutOnEnable : MonoBehaviour
{
    public float fadeTime = 1f;
    public Image img;
    IEnumerator<WaitForSeconds> FadeOut()
    {
        float t = 1f;
        while(t>0)
        {
            t -= Time.deltaTime / fadeTime;
            img.color = new Color(1,1,1,t);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    private void OnEnable() {
        StartCoroutine(FadeOut());
    }
}
