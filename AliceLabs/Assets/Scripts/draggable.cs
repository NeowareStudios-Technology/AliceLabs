using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class draggable : MonoBehaviour, IDragHandler, IEndDragHandler
{

    public bool Top;
    public bool Right;
    public RectTransform parent;
    public GameObject startPosition;
    public RectTransform Page;
    private float diffx;
    private float diffy;
    public bool OverEdge = false;
    private bool startedDrag = false;
	public void Start()
	{
        startPosition.transform.position = transform.position;
        Page = GameObject.FindGameObjectWithTag("Page").GetComponent<RectTransform>();
        //lastMouse.position.Set(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
	}

    public void Update()
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(Page, transform.position))
        {
            Debug.Log("Over the edge");
            parent.gameObject.GetComponent<ItemDragHandler>().checkEdges();
            OverEdge = true;
        }
        else
            OverEdge = false;
    }


    public void OnDrag(PointerEventData eventData)
    {
        if(startedDrag == false)
        {
            startedDrag = true;
            GetComponent<Image>().color = Color.clear;
        }
        if (RectTransformUtility.RectangleContainsScreenPoint(Page, Input.mousePosition))
        {
            transform.position = SnappedLocation(Input.mousePosition);
            diffx = startPosition.transform.position.x - transform.position.x;
            diffy = startPosition.transform.position.y - transform.position.y;
            if (Top && Right)
            {
                if(parent.rect.width > 200 || diffx < 0)
                parent.offsetMax = new Vector2(parent.offsetMax.x - diffx, parent.offsetMax.y);
                if(parent.rect.height > 150 || diffy < 0)
                    parent.offsetMax = new Vector2(parent.offsetMax.x, parent.offsetMax.y - diffy);
            }
            if (Top && !Right)
            {
                if (parent.rect.width > 200 || diffx > 0)
                    parent.offsetMin = new Vector2(parent.offsetMin.x - diffx, parent.offsetMin.y);
                if (parent.rect.height > 200 || diffy < 0)
                    parent.offsetMax = new Vector2(parent.offsetMax.x, parent.offsetMax.y - diffy);
            }
            if (!Top && !Right)
            {
                if (parent.rect.width > 200 || diffx > 0)
                    parent.offsetMin = new Vector2(parent.offsetMin.x - diffx, parent.offsetMin.y);
                if (parent.rect.height > 150 || diffy > 0)
                    parent.offsetMin = new Vector2(parent.offsetMin.x, parent.offsetMin.y - diffy);
            }
            if (!Top && Right)
            {
                if (parent.rect.height > 150 || diffy > 0)
                    parent.offsetMin = new Vector2(parent.offsetMin.x, parent.offsetMin.y - diffy);
                if (parent.rect.width > 200 || diffx < 0)
                    parent.offsetMax = new Vector2(parent.offsetMax.x - diffx, parent.offsetMax.y);
            }

        }

        transform.position = startPosition.transform.position;
    }

    private Vector3 SnappedLocation(Vector3 clickPoint)
    {
        float x = clickPoint.x;
        float y = clickPoint.y;
        float z = clickPoint.z;
        float gridh = Page.rect.height / 20f;
        float gridw = Page.rect.width / 20f;
        x = Mathf.FloorToInt(x / gridw) * gridw;
        y = Mathf.FloorToInt(y / gridh) * gridh;
        z = Mathf.FloorToInt(z / 1f) * 1f;
        return new Vector3(x, y, z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        startedDrag = false;
        GetComponent<Image>().color = Color.white;
        transform.position = startPosition.transform.position;
    }
    
    public void snapChange(float x,float y)
    {
        float gridh = Page.rect.height / 20f;
        float gridw = Page.rect.width / 20f;
        x = Mathf.FloorToInt(transform.position.x / gridw + x) * gridw +10f;
        y = Mathf.FloorToInt(transform.position.y / gridh + y) * gridh +10f;
        transform.position = new Vector2(x, y);
        diffx = startPosition.transform.position.x - transform.position.x;
        diffy = startPosition.transform.position.y - transform.position.y;
        if (Top && Right)
        {
            if (parent.rect.width > 200 || diffx < 0)
                parent.offsetMax = new Vector2(parent.offsetMax.x - diffx, parent.offsetMax.y);
            if (parent.rect.height > 150 || diffy < 0)
                parent.offsetMax = new Vector2(parent.offsetMax.x, parent.offsetMax.y - diffy);
        }
        if (Top && !Right)
        {
            if (parent.rect.width > 200 || diffx > 0)
                parent.offsetMin = new Vector2(parent.offsetMin.x - diffx, parent.offsetMin.y);
            if (parent.rect.height > 200 || diffy < 0)
                parent.offsetMax = new Vector2(parent.offsetMax.x, parent.offsetMax.y - diffy);
        }
        if (!Top && !Right)
        {
            if (parent.rect.width > 200 || diffx > 0)
                parent.offsetMin = new Vector2(parent.offsetMin.x - diffx, parent.offsetMin.y);
            if (parent.rect.height > 150 || diffy > 0)
                parent.offsetMin = new Vector2(parent.offsetMin.x, parent.offsetMin.y - diffy);
        }
        if (!Top && Right)
        {
            if (parent.rect.height > 150 || diffy > 0)
                parent.offsetMin = new Vector2(parent.offsetMin.x, parent.offsetMin.y - diffy);
            if (parent.rect.width > 200 || diffx < 0)
                parent.offsetMax = new Vector2(parent.offsetMax.x - diffx, parent.offsetMax.y);
        }
        transform.position = startPosition.transform.position;
    }
}
