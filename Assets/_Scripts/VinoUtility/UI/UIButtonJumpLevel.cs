using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VinoUtility;

namespace VinoUtility.UI{
public class UIButtonJumpLevel : MonoBehaviour
{
    public int targetLevel;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=>{GameManager.Instance.LoadLevel(targetLevel);});
    }

}
}
