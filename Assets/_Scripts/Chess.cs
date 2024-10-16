using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;




public class Chess : MonoBehaviour
{
    public readonly int[] XfourDir = {1,0,-1,0};
    public readonly int[] YfourDir = {0,-1,0,1};
    public TextMeshProUGUI text;
    int _number;
    public int Number{
        get{
            return _number;
        }
        set{
            _number = value;
            text.text = value.ToString();
            if(_number <= 0)
                Die();
        }
    }

    public int x;
    public int y;
    public void Die()
    {
        Destroy(gameObject);
    }
    
    public virtual void Settle(int _x, int _y)
    {
        x = _x;
        y = _y;
        
        for(int i = 0;i<4;i++)
        {
            var a = ChessManager.Instance.GetTile(x+XfourDir[i],y+YfourDir[i]);
            if(a == null)
                continue;
            var c = a.GetChess();
            if(c==null)
                continue;
            c.Number++;
        }
    }

    public virtual void Move(int _x, int _y)
    {
        x = _x;
        y = _y;
           
    }

    public virtual void UpdateRound()
    {

    }

    void Start()
    {
        if(text == null)
            text = GetComponentInChildren<TextMeshProUGUI>();
    }
}
