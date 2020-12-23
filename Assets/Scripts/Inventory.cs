using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] bool visableInventory = false;
    [SerializeField] GameObject[] countSlots;
    [SerializeField] GameObject[] icon;

    private void Start()
    {

    }

    private void Update()
    {
        //Debug.Log("visable" + visableInventory);
        if (Input.GetButtonDown("Fire1") && !visableInventory)
        {
            //Debug.Log("1");
            inventory.SetActive(true);
            visableInventory = !visableInventory;
        }

        if(Input.GetButtonDown("Fire2") && visableInventory)
        {
            //Debug.Log("2");
            inventory.SetActive(false);
            visableInventory = !visableInventory;
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < countSlots.Length; i++)
        {
            if (countSlots[i].GetComponent<Slot>().isFull == false)
            {
                countSlots[i].GetComponent<Slot>().isFull = true;
                icon[i].GetComponent<RawImage>().color = new Color(255, 255, 255, 255);
                icon[i].GetComponent<RawImage>().texture = item.icon;

                break;
            }

            //icon[i].GetComponent<RawImage>().texture = item.icon;
        }

        //for (int i = 0; i < countSlots.Length; i++)
        //{
        //    if (countSlots[i].GetComponent<Slot>().isFull == false)
        //    {
        //        countSlots[i].GetComponent<Slot>().isFull = true;
        //        icon[i].GetComponent<RawImage>().texture = item.itemIcon;

        //        break;
        //    }
        //}
    }

    public void RemoveItem(Item item)
    {

    }
}
