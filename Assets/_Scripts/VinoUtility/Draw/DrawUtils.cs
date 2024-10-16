using System.Collections;
using System.Collections.Generic;
using Shapes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace VinoUtility{
public static class DrawUtils
{
    public static GameObject DrawCube(Vector3 pos, float a)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = pos;
        cube.transform.localScale = new Vector3(a, a, a);
        return cube;
    }
    public static GameObject DrawSphere(Vector3 pos, float r)
    {
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.transform.localScale = new Vector3(r, r, r);
        return sphere;
    }

    public static void DrawLine(Vector2 pos1, Vector2 pos2)
    {
        
    }

    public static void DrawPoint(Vector2 pos, Color color,float radius = 1f)
    {
        var newCircle = new CircleInfo();
        newCircle.center = pos;
        newCircle.radius = radius;
        newCircle.forward = Vector3.forward;
        newCircle.fillColor = color;
        Circle.Draw(newCircle);
    }
    // public static void DrawCenterText(string content, float existTime = 1f, float fadeDuration = 1f)
    // {
    //     var go = GameObject.Instantiate(Resources.Load("FloatingText"));
    //     var fade = go.GetComponent<UICanvasGroupFade>();
    //     fade.fadeDelay = existTime;
    //     fade.duration = fadeDuration;
    //     var tmp = go.GetComponentInChildren<TextMeshProUGUI>();
    //     tmp.text = content;
    // }
}
}
