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
    private float diffx;
    private float diffy;
    private bool startedDrag = false;
	public void Start()
	{
        startPosition.transform.position = transform.position;
        //lastMouse.position.Set(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
	}

	public void OnDrag(PointerEventData eventData)
    {
        if(startedDrag == false)
        {
            startedDrag = true;
            GetComponent<Image>().color = Color.clear;
        }
        transform.position = Input.mousePosition;
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

    public void OnEndDrag(PointerEventData eventData)
    {
        startedDrag = false;
        GetComponent<Image>().color = Color.white;
        transform.position = startPosition.transform.position;
    }
}
