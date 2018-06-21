using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler {

    public RectTransform Page;
	public void Start()
	{
        Page = GameObject.FindGameObjectWithTag("Page").transform as RectTransform;
	}
	public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(Page, Input.mousePosition))
        {
            Destroy(this.gameObject);
        }

        else
            Debug.Log("Drop");
            //transform.localPosition = Vector3.zero;
        
    }

}
