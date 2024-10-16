using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GravitySource2D : MonoBehaviour
{
    public float gravityRatio = 1f;
    public float gravityRadius = 10f;
   
    [SerializeField]
    AnimationCurve gravityCurve;

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, gravityRadius);
    }
    private void FixedUpdate() {
        var targetList = Physics2D.OverlapCircleAll(transform.position,gravityRadius).ToList();
        
        foreach(var target in targetList) 
        {
            if(target.gameObject.TryGetComponent<GravityComp2D>(out var gcomp)) 
            {
                Vector2 vec = target.transform.position - transform.position;
                var force = gravityCurve.Evaluate(vec.magnitude / gravityRadius) * gravityRatio * vec.normalized;
                //实际承受的引力为 force * gravityFactor
                gcomp.AddGravity(force);
            }
        }
    }

}
