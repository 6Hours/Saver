using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static void SaveData(object obj, string name="data")
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/"+name+".bs");
        bf.Serialize(file, obj);
        file.Close();

        Debug.Log("Save " + (obj.GetType().ToString()));
    }
}
