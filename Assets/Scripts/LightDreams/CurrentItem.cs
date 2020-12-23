using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentItem : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    public int index;

    GameObject inventoryObject;
    LDInventory inventory;

    //public LDList list;
    void Start()
    {
        inventoryObject = GameObject.FindGameObjectWithTag("Player");
        inventory = inventoryObject.GetComponent<LDInventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("I live");
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (inventory.lditem[index].isDroped)
            {
                DropItem();
                RemoveItem();
            }
        }

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (inventory.lditem[index].customEvent != null)
            {
                inventory.lditem[index].customEvent.Invoke();
            }

            if (inventory.lditem[index].isRemovable)
            {
                RemoveItem();
            }
        }
    }

    public void RemoveItem()
    {
        if (inventory.lditem[index].id != 0)
        {
            if (inventory.lditem[index].count > 1)
            {
                inventory.lditem[index].count--;
            }
            else
            {
                inventory.lditem[index] = new LDItem();
            }

            inventory.DisplayItems();
        }
    }

    public void DropItem()
    {
        if (inventory.lditem[index].id != 0)
        {
            for(int i = 0; i < inventory.dataBase.transform.childCount; i++)
            {
                LDItem item = inventory.dataBase.transform.GetChild(i).GetComponent<LDItem>();

                if (item != null)
                {
                    if (inventory.lditem[index].id == item.id)
                    {
                        GameObject dropedObject = Instantiate(item.gameObject);
                        dropedObject.transform.position = new Vector3(inventoryObject.transform.position.x + 2, inventoryObject.transform.position.y);
                    }
                }
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("^^");
        GameObject dragedObject = LDDrag.dragedObject;

        if(dragedObject == null)
        {
            return;
        }
        CurrentItem currentDragedItem = dragedObject.GetComponent<CurrentItem>();

        if(currentDragedItem != null)
        {
            LDItem currentItem = inventory.lditem[GetComponent<CurrentItem>().index];
            inventory.lditem[GetComponent<CurrentItem>().index] = inventory.lditem[currentDragedItem.index];
            inventory.lditem[currentDragedItem.index] = currentItem;
            inventory.DisplayItems();
        }
    }
}
