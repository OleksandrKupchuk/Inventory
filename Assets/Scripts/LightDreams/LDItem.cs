using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class LDItem : MonoBehaviour
{
    public string nameItem;
    public int id;
    public int count;
    public bool isStackable;
    [Multiline(5)] public string descriptionItem;
    public bool isRemovable;
    public bool isDroped;
    //public Sprite icon;
    public UnityEvent customEvent;
    public string pathIcon;
    public string pathPrefab;
}
