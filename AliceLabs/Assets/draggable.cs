using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class draggable : MonoBehaviour, IDragHandler {

    public bool Top;
    public bool Right;
    public RectTransform parent;
    public GameObject startPosition;
    private float diffx;
    private float diffy;

	public void Start()
	{
        startPosition.transform.position = transform.position;
        //lastMouse.position.Set(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z);
	}

	public void OnDrag(PointerEventData eventData)
    {
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


	
}
