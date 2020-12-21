using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    //Методы Save и Load базовые, т.е. применяются другими методами


    //Save methods

    public static void Save(object obj, string name="save") //В name кроме имени также и путь к папке (опционально). Пример: Saves/savename 
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        file = File.Create(Application.dataPath + "/" + name + ".ous");
        bf.Serialize(file, obj);
        file.Close();
        Debug.Log("Save " + (obj.GetType().ToString()));
    }
    public static void SaveTemporary(object obj, string name = "save") //Перегрузка метода для сохранения с дополнительным файлом
    {
        if (File.Exists(Application.dataPath + "/" + name + ".ous"))
        {
            Save(obj, name + "_temp");
        }
        else Save(obj, name);
    }
    public static void SaveSettings() //Сохранение настроек/параметров
    {
        Settings settings = new Settings();
        Save(settings, "settings");
    }    
    public static void SaveData() //Сохранение данных игры: ландшафт, квесты и таймеры и т.д.
    {
        Data data = new Data();
        Save(data, "data");
    }
    public static void SaveMission(string missionName) //Сохранение текущей миссии
    {
        Mission mission = new Mission();
        Save(mission, missionName);
    }

    //Load methods

    public static T Load<T>(ref T obj, string name = "save") //В name кроме имени также и путь к папке (опционально). Пример: Saves/savename 
    {
        if (File.Exists(Application.dataPath + "/" + name + ".ous"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/" + name + ".ous", FileMode.Open);
            obj = (T)bf.Deserialize(file);
            file.Close();
            Debug.Log("Load " + (obj.GetType().ToString()));
            return obj;
        }
        return default(T);
    }
    public static void LoadTemporary<T>(ref T obj, ref T temp, string name = "save") //В name кроме имени также и путь к папке (опционально). Пример: Saves/savename 
    {
        Load(ref obj, name);
        Load(ref temp, name + "_temp");
    }
    public static void LoadSettings() //Загрузка настроек Settings
    {
        Settings settings = new Settings();
        Load(ref settings, "settings");
        settings.Extract(); //Извлечение данных в нужные скрипты
    }
    public static void LoadData() //Загрузка настроек игры Data
    {
        Data data = new Data();
        Load(ref data, "data");
        data.Extract(); //Извлечение данных в нужные скрипты
    }
    public static void LoadMission(string missionName) //Загрузка миссии Mission
    {
        Mission mission = new Mission();
        Load(ref mission, missionName);
        mission.Extract(); //Извлечение данных в нужные скрипты
    }
}
