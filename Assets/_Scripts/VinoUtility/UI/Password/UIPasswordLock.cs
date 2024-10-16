
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIPasswordLock : MonoBehaviour
{

    [SerializeField]
    UIShowSingleNumber[] displayText;

    public string Password;
    public UnityEvent SuccessEvent;
    
    void Update()
    {
        var nowText = "";
        foreach (var display in displayText)
        {
            nowText += display.Value.ToString();
        }
        if(nowText == Password)
        {
            SuccessEvent.Invoke();
        }
    }
}
