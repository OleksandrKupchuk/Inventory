using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[Serializable]
public class LDList
{
    public List<LDItem> listItem = new List<LDItem>();
    public int[] count = new int[12];

    public LDList(LDInventory inventory)
    {
        listItem = inventory.lditem;

        for (int i = 0; i < 12; i++)
        {
            count[i] = inventory.lditem[i].count;
        }
    }
}
