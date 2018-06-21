using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Textspawner : MonoBehaviour, IEndDragHandler, IPointerDownHandler
{

    public GameObject PrefabObject;
    public GameObject Page;
    private GameObject newObject;
    bool spawned = false;

    public void Clicked(){
        newObject = Instantiate(PrefabObject, Input.mousePosition,Quaternion.identity);
        spawned = true;
        newObject.GetComponent<ItemDragHandler>().Page = Page.transform as RectTransform;
		newObject.transform.SetParent(Page.transform);
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
