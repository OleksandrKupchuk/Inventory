using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LDSlot : MonoBehaviour
{
    public Sprite activeCell;
    private Sprite cellDefault;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        cellDefault = image.sprite;
    }

    private void OnDisable()
    {
        image.sprite = cellDefault;
    }

    public void OnMouseEnter()
    {
        image.sprite = activeCell;
    }

    public void OnMouseExit()
    {
        image.sprite = cellDefault;
    }
}
