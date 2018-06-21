using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChildDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{

    public GameObject Parent;
    public RectTransform Page;

    public void Start()
    {
        Page = GameObject.FindGameObjectWithTag("Page").transform as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Parent.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(Page, Input.mousePosition))
        {
            Destroy(Parent);
        }

        else
        {
            Debug.Log("Drop");
        }
    }
}
