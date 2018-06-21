using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Textspawner : MonoBehaviour, IEndDragHandler, IPointerDownHandler
{

    public GameObject PrefabObject;
    public GameObject Page;
    private GameObject newObject = null;
    bool spawned = false;

    public void Update()
    {
        if (Input.GetMouseButton(0) && newObject)
        {
            newObject.transform.position = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) && newObject)
        {
            newObject = null;
        }
    }

    public void Clicked(){
        newObject = Instantiate(PrefabObject, Input.mousePosition,Quaternion.identity);
        spawned = true;
        newObject.GetComponent<ItemDragHandler>().Page = Page.transform as RectTransform;
		newObject.transform.SetParent(Page.transform);
        RectTransform rt = newObject.GetComponent<RectTransform>();
        RectTransform pt = Page.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(pt.rect.width/5f,pt.rect.height/10f);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        spawned = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Clicked();
    }
}
