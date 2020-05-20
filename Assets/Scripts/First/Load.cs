using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Load : MonoBehaviour
{
    public static T LoadData<T>(ref T obj, string name="data")
    {
        if(File.Exists(Application.dataPath+"/"+name+".bs"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/" + name + ".bs", FileMode.Open);
            obj = (T)bf.Deserialize(file);
            file.Close();

            Debug.Log("Load " + (obj.GetType().ToString()));
            return obj;
        }
        return default(T);
    }
}
