using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VinoUtility{

[System.Serializable]
public struct ParallaxLayer
{
    public Transform transform;
    public float parallaxFactor;
}

public class ParallaxCamera : MonoBehaviour
{
    public ParallaxLayer[] parallaxLayers;
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var moveOffset = new Vector2(transform.position.x - lastPos.x,transform.position.y-lastPos.y);
        foreach(var layer in parallaxLayers)
        {
            var offset = moveOffset * layer.parallaxFactor;
            layer.transform.position = new Vector3(layer.transform.position.x + offset.x, layer.transform.position.y + offset.y, layer.transform.position.z);
        }
        lastPos = transform.position;
    }
}

}