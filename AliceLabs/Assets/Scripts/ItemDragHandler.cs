using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler {
    public draggable TL;
    public draggable BL;
    public draggable TR;
    public draggable BR;
    public RectTransform Page;
    public RectTransform rt;
    private snapGrid pageGrid;
    bool snapped = false;

	public void Start()
	{
        Page = GameObject.FindGameObjectWithTag("Page").transform as RectTransform;
        pageGrid = Page.GetComponent<snapGrid>();
        rt = gameObject.GetComponent<RectTransform>();
	}
   
    public void OnDrag(PointerEventData eventData)
    {


        if (RectTransformUtility.RectangleContainsScreenPoint(Page, Input.mousePosition))
        {

            Vector3 newLocation = pageGrid.SnappedLocation(Input.mousePosition);

            if (newLocation.x > 10f && newLocation.x < Page.sizeDelta.x - (rt.sizeDelta.x + 10f)  && newLocation.y < Page.sizeDelta.y -10f && newLocation.y > rt.sizeDelta.y)
            {
                Debug.Log("snap");
                Debug.Log("Location y: " + newLocation.y + " SizeDelta: " + rt.sizeDelta.y + " Page SD: " + Page.sizeDelta.y);
                transform.position = newLocation;
                snapped = true;
            }
            else
            {
                transform.position = newLocation;
                checkEdges();
            }
        }
        else
        {
            if (snapped)
            {

                snapped = false;
            }
            transform.position = Input.mousePosition;
        }

    }

        
   

    public void checkEdges()
    {
        Debug.Log("Checking Edges");
        //this function checks to see if any of the draggables are over the edge and correctly puts them in the right place
        //Right
        if (BR.OverEdge && TR.OverEdge && !BL.OverEdge && !TL.OverEdge && enoughDistance(true))
        {
            BR.snapChange(-1,0);
            TR.snapChange(-1, 0);
            return;
        }
        //Bottom
        if (BR.OverEdge && BL.OverEdge && !TL.OverEdge && !TR.OverEdge && enoughDistance(false))
        {
            BR.snapChange(0,1);
            BL.snapChange(0, 1);
            return;
        }
        //Left
        if (TL.OverEdge && BL.OverEdge && !TR.OverEdge && !BR.OverEdge && enoughDistance(true))
        {
            TL.snapChange(1, 0);
            BL.snapChange(1, 0);
            return;
        }
        //Top
        if (TL.OverEdge && TR.OverEdge && !BR.OverEdge && !BL.OverEdge && enoughDistance(false))
        {
            TL.snapChange(0, -1);
            TR.snapChange(0, -1);
            return;
        }
    }

    private bool enoughDistance(bool LR)
    {
        if (LR)
        {
            if (rt.sizeDelta.x > 250)
                return true;
            return false;
        }
        if (rt.sizeDelta.y > 200)
           return true;
        return false;
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
