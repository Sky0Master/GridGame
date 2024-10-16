using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VinoUtility.UI {
public class UICanvasGroupFade : MonoBehaviour
{
    public float fadeDelay = 1f;
    public float duration = 1f;
    public CanvasGroup canvasGroup;
    public void FadeOut()
    {
        StartCoroutine(LerpUtility.Lerp(1f,0f,duration,(v) => {canvasGroup.alpha = v;},()=>{canvasGroup.gameObject.SetActive(false);}));
    }
    void Start()
    {
        if(fadeDelay < 0) return;
        if(canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        Invoke("FadeOut",fadeDelay);
    }

}
}