using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class SpringNode : MonoBehaviour
{
    Transform paNode;
    Transform leftNode;
    Transform rightNode;
    
    int _index;
    
    public float dist = 0.5f;

    public float k = 1f;
    
    Rigidbody2D _rb;

    void Start()
    {
        paNode = transform.parent;
        _index = transform.GetSiblingIndex(); 
        if(_index <= 0 || _index >= paNode.childCount - 1)
        {   
            this.enabled = false;
            return;
        }
        leftNode = paNode.GetChild(_index - 1);
        rightNode = paNode.GetChild(_index + 1);
        _rb = GetComponent<Rigidbody2D>();
    }
    public void SetLeftNode(Transform l)
    {
        leftNode = l;
    }
    public void SetRightNode(Transform r)
    {
        rightNode = r;
    }
    // public Vector2 CalculatePosition(Vector2 curPos, Vector2 posA, Vector2 posB)
    // {
    //     var distA = Vector2.Distance(curPos, posA);
    //     var distB = Vector2.Distance(curPos, posB);
    //     var AB = Vector2.Distance(posA, posB);
    //     var k = distA / (distA + distB);
    //     var dir = (posB - posA).normalized;
    //     return posA + dir * k * Mathf.Min(AB ,maxDistance);
    // }
    public Vector2 CalculateForce(Vector2 curPos, Vector2 posA, Vector2 posB)
    {
        //f = kx
        var xA = posA - curPos;
        var xB = posB - curPos;
        var xA0 = (posA - curPos).normalized * dist;
        var xB0 = (posB - curPos).normalized * dist;
        
        var fA = k * (xA-xA0);
        var fB = k * (xB-xB0);
        return (fA + fB);
    }

    private void FixedUpdate() {
        //transform.position = CalculatePosition(transform.position, leftNode.position, rightNode.position);
        //transform.position = Vector2.Lerp(leftNode.position, rightNode.position, 0.5f);
        _rb.AddForce(CalculateForce(transform.position, leftNode.position, rightNode.position),ForceMode2D.Force); //(
    }
    
}
