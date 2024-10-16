using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using VinoUtility;

public class DrawTest : MonoBehaviour
{
    public float turnFraction = 1.618f;
    public int pointNum = 1000;

    public float radius = 0.2f;

    public float A = 20f; 

    public float pow = 1f;

    public Color color;
    public Color highlightColor;

    public int highlightOffset = 0;
    public int highlight = 1;

    [Header("Increase")]

    public float highlightIncrease = 0f;
    private float _hlt;

    public float powIncrease = 0f;

    public float pointNumIncrease = 0f;
    private float _pnt;

    public void Draw()
    {
        for(int i=0;i<pointNum;i++)
        {  
            float dst = Mathf.Pow(i/(pointNum - 1.0f), pow);
            float angle = 2 * Mathf.PI * turnFraction * i;
            float x = A * dst * Mathf.Cos(angle);
            float y = A * dst * Mathf.Sin(angle);

            var col = (i + highlightOffset) % highlight == 0? highlightColor : color;
            DrawUtils.DrawPoint(new Vector2(x,y), col ,radius);
        } 
    }

    void Update()
    {
        Draw();
        if(highlightIncrease > 0)
        {
            _hlt += Time.deltaTime * highlightIncrease;
            if(_hlt >=1)
            {
                _hlt = 0;
                highlight++;
            }
        }
        if(powIncrease != 0)
        {
            pow += Time.deltaTime * powIncrease;
        }
        if(pointNumIncrease != 0)
        {
            _pnt += Time.deltaTime * pointNumIncrease;
            if(_pnt >= 1)
            {
                _pnt = 0;
                pointNum++;
            }
        }
    }
}
