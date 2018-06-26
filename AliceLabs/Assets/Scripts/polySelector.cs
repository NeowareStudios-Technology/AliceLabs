using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyToolkit;
public class polySelector : MonoBehaviour {
    private GameObject model;
    public GameObject referenceModel;
    public string URL = "assets/8nMC2GZProF";
	public void SelectAsset()
    {
        PolyApi.GetAsset(URL, MyCallback);
    }
    public void SetURL(string a)
    {
        URL = a;
    }

    void MyCallback(PolyStatusOr<PolyAsset> result)
    {
        if (!result.Ok)
        {
            // Handle error.
            return;
        }
        // Success. result.Value is a PolyAsset
        // Do something with the asset here.
        PolyApi.Import(result.Value, PolyImportOptions.Default(), MyImportCallback);
    }

    void MyImportCallback(PolyAsset asset, PolyStatusOr<PolyImportResult> result)
    {
        if (!result.Ok)
        {
            // Handle error.
            return;
        }
        // Success. Place the result.Value.gameObject in your scene.
        if (model)
            Destroy(model);
        model = result.Value.gameObject;
        model.transform.position = referenceModel.transform.position;
        model.transform.parent = referenceModel.transform.parent;
        model.transform.localScale = new Vector3(100f,100f,100f);
        referenceModel.SetActive(false);

    }
}
