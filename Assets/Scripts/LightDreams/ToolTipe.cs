using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipe : MonoBehaviour
{
    private LDInventory inventory;
    //public LDList list;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<LDInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        //inventory.toolTipeObject.transform.position = Input.mousePosition;
        //inventory.toolTipeObject.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition;
        //Debug.Log("mouse pos" + Input.mousePosition);
    }

    private void OnMouseEnter()
    {
        //Debug.Log("Enter");
        CurrentItem currentItem = GetComponent<CurrentItem>();
        LDItem item = inventory.lditem[currentItem.index];

        //Debug.Log("cell id = " + item.id);

        if (item.id != 0)
        {
            inventory.toolTipeObject.SetActive(true);

            //inventory.toolTipeObject.transform.position = new Vector3(inventory.cellContainer.transform.GetChild(currentItem.index).position.x, inventory.cellContainer.transform.GetChild(currentItem.index).position.y, 0);
            //Debug.Log("position = " + inventory.cellContainer.transform.position);

            //inventory.icon.sprite = item.icon;
            //inventory.itemName.text = item.nameItem;
            //inventory.description.text = item.descriptionItem;
        }
    }

    private void OnMouseOver()
    {
        CurrentItem currentItem = GetComponent<CurrentItem>();
        LDItem item = inventory.lditem[currentItem.index];

        if (item.id != 0 && item.count != 0)
        {
            //inventory.toolTipeObject.SetActive(true);

            inventory.toolTipeObject.transform.position = new Vector3(inventory.cellContainer.transform.GetChild(currentItem.index).position.x + 0.3f, inventory.cellContainer.transform.GetChild(currentItem.index).position.y - 0.1f, 0);
            //Debug.Log("position = " + inventory.cellContainer.transform.position);

            //inventory.icon.sprite = item.icon;
            inventory.icon.sprite = Resources.Load<Sprite>(inventory.lditem[currentItem.index].pathIcon);
            inventory.itemName.text = item.nameItem;
            inventory.description.text = item.descriptionItem;
        }

        else
        {
            inventory.toolTipeObject.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        //Debug.Log("Exit");
        inventory.toolTipeObject.SetActive(false);
    }

    private void OnDisable()
    {
        inventory.toolTipeObject.SetActive(false);
    }
}
