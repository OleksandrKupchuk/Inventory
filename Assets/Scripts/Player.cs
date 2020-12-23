using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] LDInventory inventory;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.GetComponent<LDItem>())
    //    {
    //        for(int i = 0; i < inventory.lditem.Count; i++)
    //        {
    //            if(inventory.lditem[i].id == 0)
    //            {
    //                //inventory.lditem[i] = collision.gameObject.GetComponent<LDItem>();
    //                //inventory.lditem[i].count = 1;
    //                //DisplayItems();
    //                //Destroy(collision.gameObject);
    //                //break;
    //                AddItem(collision.GetComponent<LDItem>());
    //                break;
    //            }
    //        }
    //    }
    //}

    //private void AddItem(LDItem currentItem)
    //{
    //    if (currentItem.isStackable)
    //    {
    //        AddStackableItem(currentItem);
    //    }

    //    else
    //    {
    //        AddUnstackableItem(currentItem);
    //    }
    //}

    //private void AddUnstackableItem(LDItem currentItem)
    //{
    //    for (int i = 0; i < inventory.lditem.Count; i++)
    //    {
    //        if (inventory.lditem[i].id == 0)
    //        {
    //            inventory.lditem[i] = currentItem;
    //            inventory.lditem[i].count = 1;
    //            DisplayItems();
    //            Destroy(currentItem.gameObject);
    //            break;
    //        }
    //    }
    //}

    //private void AddStackableItem(LDItem currentItem)
    //{
    //    for(int i = 0; i < inventory.lditem.Count; i++)
    //    {
    //        if(inventory.lditem[i].id == currentItem.id)
    //        {
    //            inventory.lditem[i].count++;
    //            DisplayItems();
    //            Destroy(currentItem.gameObject);
    //            return;
    //        }
    //    }

    //    AddUnstackableItem(currentItem);
    //}

    //private void DisplayItems()
    //{
    //    for(int i = 0; i < inventory.lditem.Count; i++)
    //    {
    //        Transform cell = inventory.cellContainer.transform.GetChild(i);
    //        Transform icon = cell.GetChild(0);
    //        Transform count = icon.GetChild(0);
    //        Text txt = count.GetComponent<Text>();

    //        Image image = icon.GetComponent<Image>();

    //        if (inventory.lditem[i].id != 0)
    //        {
    //            image.sprite = Resources.Load<Sprite>(inventory.lditem[i].pathIcon);
    //            image.enabled = true;
    //            if(inventory.lditem[i].count > 1)
    //            {
    //                txt.text = inventory.lditem[i].count.ToString();
    //            }
    //        }

    //        else
    //        {
    //            image.enabled = false;
    //            image.sprite = null;
    //            txt.text = null;
    //        }
    //    }
    //}
}
