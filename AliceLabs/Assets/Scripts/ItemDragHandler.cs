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
       
            Debug.Log("snap");
            transform.position = SnappedLocation(Input.mousePosition);
        
        
   
            //transform.position = Input.mousePosition;
    }

    private Vector3 SnappedLocation(Vector3 clickPoint)
    {
        float x = clickPoint.x;
        float y = clickPoint.y;
        float z = clickPoint.z;
        float gridh = Page.rect.height / 10f;
        float gridw = Page.rect.width / 10f;
        x = Mathf.FloorToInt(x / gridw) * gridw;
        y = Mathf.FloorToInt(y / gridh) * gridh;
        z = Mathf.FloorToInt(z / 1f) * 1f;
        return new Vector3(x, y, z);
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
