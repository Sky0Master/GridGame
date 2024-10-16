using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShowSingleNumber : MonoBehaviour
{
    public int Value {
        get => _value;
        set
        {
            value %= 10;
            _value = value;
            numText.text = value.ToString();
        }
    }
    private int _value;

    [SerializeField]
    TMP_Text numText;
    [SerializeField]
    Button up;
    [SerializeField]
    Button down;
    private void Awake()
    {
        up.onClick.AddListener(Up);
        down.onClick.AddListener(Down);
        
    }
    public void Up()
    {
        Value++;
        if(Value>=10)
            Value = 0;
    }
    public void Down()
    {
        Value--;
        if(Value<=-1)
            Value = 9;
        
    }

}
