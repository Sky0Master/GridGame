using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverEffect : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{

    public float duration = 0.5f;
    public float scaleTimes = 1.2f;
    float _stScalex;
    float _stScaley;
    //public AnimationCurve scaleCurve;
    IEnumerator<WaitForSeconds> DoScale(float startScale, float endScale,float duration)
    {
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            var value = Mathf.Lerp(startScale, endScale, t / duration);
            //var value = scaleCurve.Evaluate(t / duration);
            transform.localScale = new Vector3(value * _stScalex, value * _stScaley, 0);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(DoScale(1,scaleTimes,duration));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
         StartCoroutine(DoScale(scaleTimes,1,duration));
    }

    // Start is called before the first frame update
    void Start()
    {
        _stScalex = transform.localScale.x;
        _stScaley = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
