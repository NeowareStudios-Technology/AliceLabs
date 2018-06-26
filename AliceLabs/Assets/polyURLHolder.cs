using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polyURLHolder : MonoBehaviour {

    public string URL;
    public polySelector p;
    public void Start()
    {
        p = GameObject.FindGameObjectWithTag("select").GetComponent<polySelector>();
    }
    public void URLSetter()
    {
        p.SetURL(URL);
    }
}
