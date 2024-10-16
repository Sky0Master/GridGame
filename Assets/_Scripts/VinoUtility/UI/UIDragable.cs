using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class UIDragable : MonoBehaviour,IBeginDragHandler,IEndDragHandler, IDragHandler
{
    Transform pa;
    bool _isDragging;
    //public int uId;
    public UnityEvent endDragEvent;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        //transform.SetParent(pa.parent,false);
        _isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.SetParent(pa, false);
        _isDragging = false;
        endDragEvent?.Invoke();
    }
    public void OnDrag(PointerEventData eventData)
    {
        
    }

    void Start()
    {
        pa = transform.parent;
    }


    void Update()
    {
        if (_isDragging)
        {
            transform.position = Input.mousePosition;
        }
    }


}
