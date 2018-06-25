using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapGrid : MonoBehaviour {

    public RectTransform Page;
    public float rightmargin = 5f;
    public Vector3 SnappedLocation(Vector3 clickPoint)
    {
        float x = clickPoint.x;
        float y = clickPoint.y;
        float z = clickPoint.z;
        float gridh = Page.rect.height / 10f;
        float gridw = Page.rect.width / 10f;
        x = Mathf.FloorToInt(x / gridw) * gridw + rightmargin;
        y = Mathf.FloorToInt(y / gridh + 1f) * gridh;
        z = Mathf.FloorToInt(z / 1f) * 1f;
        return new Vector3(x, y, z);
    }
    public Vector3 SnappedCloseLocation(Vector3 clickPoint,float LR,float TB)
    {
        float x = clickPoint.x;
        float y = clickPoint.y;
        float z = clickPoint.z;
        float gridh = Page.rect.height / 10f;
        float gridw = Page.rect.width / 10f;
        x = Mathf.FloorToInt(x / gridw) * gridw + rightmargin;
        y = Mathf.FloorToInt(y / gridh) * gridh;
        z = Mathf.FloorToInt(z / 1f) * 1f;
        return new Vector3(x, y, z);
    }
}
