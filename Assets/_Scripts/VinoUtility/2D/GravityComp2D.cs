using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GravityComp2D : MonoBehaviour
{
    Rigidbody2D _rb;
    public float gravityFactor = 1f;

    //是否可以受到引力
    public bool canImpact = true;

    public void AddGravity(Vector2 gravityForce)
    {
        if(!canImpact) return;
        _rb.AddForce(gravityForce * gravityFactor, ForceMode2D.Force);
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
}
