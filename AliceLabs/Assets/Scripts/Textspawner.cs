using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Textspawner : MonoBehaviour, IDragHandler, IEndDragHandler
{

    public GameObject PrefabObject;
    public GameObject Page;
    private GameObject newObject;
    bool spawned = false;

    public void OnDrag(PointerEventData eventData)
    {
       if(!RectTransformUtility.RectangleContainsScreenPoint(this.transform as RectTransform, Input.mousePosition)&&!spawned){
            newObject = Instantiate(PrefabObject, Page.transform);
            spawned = true;
            newObject.GetComponent<ItemDragHandler>().Page = Page.transform as RectTransform;
        }
            
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        spawned = false;
    }

}
