using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LDDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject dragedObject;

    private LDInventory inventory;

    //public LDList list;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<LDInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("BeginDrag");
        dragedObject = gameObject;
        inventory.dragPrefab.SetActive(true);

        if (dragedObject.GetComponent<CurrentItem>() !=  null)
        {
            int index = dragedObject.GetComponent<CurrentItem>().index;
            //inventory.dragPrefab.GetComponent<Image>().sprite = list.lditem[index].icon;
            inventory.dragPrefab.GetComponent<Image>().sprite = Resources.Load<Sprite>(inventory.lditem[index].pathIcon);
            inventory.dragPrefab.GetComponent<CanvasGroup>().blocksRaycasts = false; // компонент не обов'язковий, так як працює і без нього

            if (inventory.lditem[index].count > 1)
            {
                inventory.dragPrefab.transform.GetChild(0).GetComponent<Text>().text = inventory.lditem[index].count.ToString();
            }

            else
            {
                inventory.dragPrefab.transform.GetChild(0).GetComponent<Text>().text = null;
            }

            //if (list.lditem[index].icon == null)
            //{
            //    dragedObject = null;
            //    inventory.dragPrefab.SetActive(false);
            //}

            if (inventory.lditem[index].pathIcon == null) 
            {
                dragedObject = null;
                inventory.dragPrefab.SetActive(false);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag");
        inventory.dragPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector3(Input.mousePosition.x - 580f, Input.mousePosition.y - 200f);
        //inventory.dragPrefab.transform.localPosition = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && inventory.lditem[GetComponent<CurrentItem>().index].id != 0)
        {
            dragedObject.GetComponent<CurrentItem>().DropItem();
            dragedObject.GetComponent<CurrentItem>().RemoveItem();
        }
        //Debug.Log("EndDrag");
        dragedObject = null;
        inventory.dragPrefab.SetActive(false);
        inventory.dragPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
