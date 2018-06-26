using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyToolkit;
using UnityEngine.UI;

public class importPolyThumbnails : MonoBehaviour {

    public Text keyword;
    public RawImage thumbPrefab;
    private RawImage thumb;
    public GameObject content;
    private int count;

    public void GetThumbnails()
    {
        for (int x = 0; x < content.transform.childCount; x++)
            Destroy(content.transform.GetChild(x).gameObject);
        PolyListAssetsRequest req = new PolyListAssetsRequest();
        count = 0;
        req.keywords = keyword.text;
        PolyApi.ListAssets(req, MyCallback);
    }

    void MyCallback(PolyStatusOr<PolyListAssetsResult> result)
    {
        if (!result.Ok)
        {
            Debug.Log("Poly list fail");
            // Handle error.
            return;
        }
        // Success. result.Value is a PolyListAssetsResult and
        // result.Value.assets is a list of PolyAssets.
        for (int i = 0; i < Mathf.Min(30, result.Value.assets.Count); i++) { 
                PolyApi.FetchThumbnail(result.Value.assets[i], MyThumbnailCallback);
        }
    }

    void MyThumbnailCallback(PolyAsset asset, PolyStatus status)
    {
        if (!status.ok)
        {
            Debug.Log("Loading thumbnails fail");
            // Handle error;
            return;
        }
        // Display the asset.thumbnailTexture.
        Debug.Log("Loading thumbnails");
        thumb = Instantiate(thumbPrefab,content.transform);
        count++;
        //Rect rec = new Rect(0, 0, asset.thumbnailTexture.width, asset.thumbnailTexture.height);
        //thumb = Sprite.Create(asset.thumbnailTexture, rec, new Vector2(0.5f, 0.5f), 100);
        thumb.texture = asset.thumbnailTexture;
        thumb.GetComponent<polyURLHolder>().URL = asset.name;

    }
}
