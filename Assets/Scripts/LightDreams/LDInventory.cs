using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

[Serializable]
public class LDInventory : MonoBehaviour
{
    [HideInInspector] public List<LDItem> lditem;

    public GameObject dataBase;

    public GameObject cellContainer;
    public KeyCode showInventory;

    [Header("Message")]
    public GameObject messageManager;
    public GameObject message;

    [Header("ToolTipe")]
    public GameObject toolTipeObject;
    public Image icon;
    public Text itemName;
    public Text description;

    [Header("Drag Item")]
    public GameObject dragPrefab;

    [Header("Save System")]
    public string filePath;
    //public LDList list;
    //public GameObject objectList;

    void Start()
    {
        toolTipeObject.SetActive(false);

        lditem = new List<LDItem>();

        cellContainer.SetActive(false);

        for(int i = 0; i < cellContainer.transform.childCount; i++)
        {
            //lditem.Add(new LDItem());
            lditem.Add(new LDItem());
            cellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index = i;
        }
    }

    void Update()
    {
        ToggleInventory();
    }

    public void SaveInventory()
    {
        LDList data = new LDList(this);
        //Debug.Log("Save");
        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(filePath, json);

        Debug.Log("Save");
    }

    public void LoadInventory()
    {
        Debug.Log("Load");
        string loadString = File.ReadAllText(filePath);
        LDList data = JsonUtility.FromJson<LDList>(loadString);

        //lditem = data.listItem;


        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            if (data.listItem[i] != null)
            {
                lditem[i] = data.listItem[i];
                lditem[i].count = data.count[i];
            }
        }

        DisplayItems();
    }

    public void DisplayList()
    {
        Debug.Log("List");
        for (int i = 0; i < lditem.Count; i++)
        {
            //Debug.Log($"Cell {i} " + lditem[i].id);
            Debug.Log($"Cell count №{i} - " + lditem[i].count);
        }
    }

    private void ToggleInventory()
    {
        if (Input.GetKeyDown(showInventory))
        {
            if (cellContainer.activeSelf)
            {
                cellContainer.SetActive(false);
            }

            else
            {
                cellContainer.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LDItem>())
        {
            LDItem currentItem = collision.gameObject.GetComponent<LDItem>();

            AddItem(currentItem);
            Message(currentItem);
        }
    }

    private void Message(LDItem currentItem)
    {
        GameObject messageOject = Instantiate(message);
        messageOject.transform.SetParent(messageManager.transform);

        Image messageImage = messageOject.transform.GetChild(0).GetComponent<Image>();
        //messageImage.sprite = currentItem.icon;
        messageImage.sprite = Resources.Load<Sprite>(currentItem.pathIcon);

        Text messageText = messageOject.transform.GetChild(1).GetComponent<Text>();
        messageText.text = currentItem.nameItem;
    }

    private void AddItem(LDItem currentItem)
    {
        if (currentItem.isStackable)
        {
            AddStackableItem(currentItem);
        }

        else
        {
            AddUnstackableItem(currentItem);
        }
    }

    private void AddUnstackableItem(LDItem currentItem)
    {
        for (int i = 0; i < lditem.Count; i++)
        {
            if (lditem[i].id == 0)
            {
                lditem[i] = currentItem;
                lditem[i].count = 1;
                DisplayItems();
                Destroy(currentItem.gameObject);
                break;
            }
        }
    }

    private void AddStackableItem(LDItem currentItem)
    {
        for (int i = 0; i < lditem.Count; i++)
        {
            if (lditem[i].id == currentItem.id)
            {
                lditem[i].count++;
                DisplayItems();
                Destroy(currentItem.gameObject);
                return;
            }
        }

        AddUnstackableItem(currentItem);
    }

    public void DisplayItems()
    {
        for (int i = 0; i < lditem.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Transform count = icon.GetChild(0);
            Text txt = count.GetComponent<Text>();

            Image image = icon.GetComponent<Image>();

            if (lditem[i].id != 0)
            {
                //image.sprite = list.lditem[i].icon;
                image.sprite = Resources.Load<Sprite>(lditem[i].pathIcon);
                image.enabled = true;

                if (lditem[i].count > 1)
                {
                    txt.text = lditem[i].count.ToString();
                }
                else
                {
                    txt.text = null;
                }
            }

            else
            {
                image.enabled = false;
                image.sprite = null;
                txt.text = null;
            }
        }
    }
}
