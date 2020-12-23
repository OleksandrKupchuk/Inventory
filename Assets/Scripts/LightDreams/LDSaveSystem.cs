using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class LDSaveSystem 
{
    public static void SaveInventory(LDInventory inventory)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string pathSave = Application.persistentDataPath + "/inventory.date";

        FileStream stream = new FileStream(pathSave, FileMode.Create);

        LDList data = new LDList(inventory);

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static LDList LoadInventory()
    {
        string pathSave = Application.persistentDataPath + "/inventory.date";

        if (File.Exists(pathSave))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(pathSave, FileMode.Open);

            LDList data = formatter.Deserialize(stream) as LDList;

            stream.Close();

            return data;
        }

        else
        {
            Debug.LogError("Save file not found in " + pathSave);
            return null;
        }
    }
}
