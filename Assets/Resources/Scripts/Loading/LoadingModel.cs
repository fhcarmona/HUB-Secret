using System;
using UnityEngine;

[Serializable]
public class LoadingModel
{
    public GameObject model;
    public Vector3 scale;
    public string title;
    [TextArea]
    public string description;
}
