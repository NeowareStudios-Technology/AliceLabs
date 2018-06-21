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
    private bool startedDrag = false;
	public void Start()
	{
        startPosition.transform.position = transform.position;
        Page = GameObject.FindGameObjectWithTag("Page").GetComponent<RectTransform>();
        //lastMouse.position.Set(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
	}

	public void OnDrag(PointerEventData eventData)
    {
        if(startedDrag == false)
        {
            startedDrag = true;
            GetComponent<Image>().color = Color.clear;
        }
        transform.position = SnappedLocation(Input.mousePosition);
        diffx = startPosition.transform.position.x - transform.position.x;
        diffy = startPosition.transform.position.y - transform.position.y;
        if (Top && Right)
        {
            parent.offsetMin = new Vector2(parent.offsetMin.x, parent.offsetMin.y);
            parent.offsetMax = new Vector2(parent.offsetMax.x - diffx, parent.offsetMax.y - diffy);
        }
        if (Top && !Right)
        {
            parent.offsetMin = new Vector2(parent.offsetMin.x - diffx, parent.offsetMin.y);
            parent.offsetMax = new Vector2(parent.offsetMax.x, parent.offsetMax.y - diffy);
        }
        if (!Top && !Right)
        {
            parent.offsetMin = new Vector2(parent.offsetMin.x - diffx, parent.offsetMin.y - diffy);
            parent.offsetMax = new Vector2(parent.offsetMax.x, parent.offsetMax.y);
        }
        if (!Top && Right)
        {
            parent.offsetMin = new Vector2(parent.offsetMin.x, parent.offsetMin.y - diffy);
            parent.offsetMax = new Vector2(parent.offsetMax.x - diffx, parent.offsetMax.y);
        }



		
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
        startedDrag = false;
        GetComponent<Image>().color = Color.white;
        transform.position = startPosition.transform.position;
    }
}
