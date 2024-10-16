using UnityEngine;
using UnityEngine.UI;

public class UISelectRect : MonoBehaviour
{
    public GameObject rectPrefab; // 框选矩形预制体
    private Image rectImage;
    private Vector2 startPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 鼠标按下时，创建一个新的矩形Image，并记录起始位置
            rectImage = Instantiate(rectPrefab).GetComponent<Image>();
            rectImage.transform.SetParent(transform);
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && rectImage != null)
        {
            var endPos = (Vector2)Input.mousePosition;
            var width = Mathf.Abs(endPos.x - startPos.x);
            var height = Mathf.Abs(endPos.y - startPos.y);

            // 设置矩形的位置和大小
            rectImage.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, Mathf.Min(startPos.x, endPos.x), width);
            rectImage.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, Mathf.Min(startPos.y, endPos.y), height);
           
            // if(endPos.x > startPos.x && endPos.y < startPos.y)
            // {
            //     Rect rect = new Rect(startPos.x, endPos.y, width, height);
            //     rectImage.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, rect.x, rect.width);
            //     rectImage.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, rect.y, rect.height);
            // }
        }
        if (Input.GetMouseButtonUp(0) && rectImage != null)
        {
            GetSelection(rectImage.rectTransform.rect);
            Destroy(rectImage.gameObject);
        }
    }
    public void GetSelection(Rect selectionRect)
    {
        //get all the gameobjects in the selectionRect
        foreach(var go in FindObjectsOfType<GameObject>())
        {
            var pos = (Vector2)Camera.main.WorldToScreenPoint(go.transform.position);
            if(selectionRect.Contains(pos))
            {
                Debug.Log(go.name);
                if(go.TryGetComponent<SpriteRenderer>(out var spriteRenderer)) 
                    spriteRenderer.color = Color.red;
                    
            }
        }

    
    }


}