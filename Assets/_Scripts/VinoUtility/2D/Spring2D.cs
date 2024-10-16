using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using VinoUtility;

public class Spring2D : MonoBehaviour
{
    List<SpringNode> nodes;
    public int nodeNum;
    public float k = 100f;
    public float dist = 0.5f;
    public Sprite nodeSprite;

    [ContextMenu("Generate")]
    private void Init() {
        TransformExt.DestroyAllChildrenEditor(transform);
        nodes = new List<SpringNode>();
        for (int i = 0; i < nodeNum; i++) {
            SpringNode node = new GameObject("Node" + i).AddComponent<SpringNode>();
            node.transform.parent = transform;
            node.transform.localPosition = new Vector3(i*dist,0,0);
            node.AddComponent<SpriteRenderer>().sprite = nodeSprite;
            var nodeRb = node.AddComponent<Rigidbody2D>();
            nodeRb.bodyType = RigidbodyType2D.Dynamic;
            nodes.Add(node);
        }

    }

    public void CreateNodes()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
