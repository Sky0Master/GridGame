using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VinoUtility;

public class SwirlTest : MonoBehaviour
{
    [Header("Grid Info")]
    public int width;
    public int height;
    public float size = 1f;
    List<Transform> cubes;

    [Header("Swirl Info")]
    public Vector3 center;
    
    //转速
    public float w = 10f;
    
    public float fallWithR = 2f;

    public float maxCollapseRadius = 10f;

    private float _t;

    public bool isSwirl = false;
    public void GenerateGrid()
    {
        cubes = new List<Transform>();
        for(int i = 0; i < width ; i++)
        {
            for(int j = 0; j < height; j++)
            {
                var go = DrawUtils.DrawCube(new Vector3(-width*size/2+i*size,0,-height*size/2 + j*size),size);
                go.GetComponent<Collider>().enabled = false;
                cubes.Add(go.transform);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }


    public void Swirl()
    {
        foreach(var cube in cubes)
        {
            cube.LookAt(center);
            
            var x = cube.position.x;
            var y = cube.position.y;
            var z = cube.position.z;
            var r = (x-center.x) * (x-center.x) + (z-center.z) * (z-center.z);
            r = Mathf.Sqrt(r);
           
            var theta = Mathf.Rad2Deg * Mathf.Acos((x - center.x) / (r + 0.01f));
            var newTheta = theta + w * Time.deltaTime;
            var newx = r * Mathf.Cos(newTheta * Mathf.Deg2Rad) + center.x;
            var newz = r * Mathf.Sin(newTheta * Mathf.Deg2Rad) + center.z;
            var newy = y + fallWithR * (_t - r * fallWithR) * Time.deltaTime;
            cube.position = new Vector3(newx, newy,newz);
        }
    }
    // Update is called once per frame
    void Update()
    {
        _t += Time.deltaTime;
        if(isSwirl)
            Swirl();
    }
}
