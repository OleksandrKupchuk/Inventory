using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Texture2D icon;
    public string nameItem;
    [TextArea(10, 5)] public string itemDescription;
    public int itemDamage;
    public int itemArmor;

    [SerializeField] Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //do something
            inventory.AddItem(this);
        }
    }
}
