using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform Page = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(Page, Input.mousePosition)) {
            Debug.Log("Drop item");
        }
    }
}
