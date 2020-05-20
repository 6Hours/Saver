using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    public string Symbols;
    public List<string> list;
    private Dictionary<string, int> dictionary=new Dictionary<string, int>();


    private void Start()
    {
        string[] param = BaseCode.Decode(Load.LoadData<string>(ref Symbols)).Split('|');


        Symbols = param[0];

        if(param.Length>1&&param[1]!="") list = new List<string>(param[1].Split(',')).ToList(); //List

        if (param.Length > 2&param[2]!="") //Dictionary
        {
            string[] dictionaryElems = param[2].Split(';');
            for (int i = 0; i < dictionaryElems.Length; i++)
            {
                string[] values = dictionaryElems[i].Split(',');
                dictionary.Add(values[0], int.Parse(values[1]));
                Debug.Log(values[0] + " = " + int.Parse(values[1]));
            }
        }
    }
    private void OnApplicationQuit()
    {
        //dictionary.Add("health", 10);
        //dictionary.Add("mana", 20);

        var pairs = dictionary.Select(x => string.Format("{0}{1}{2}", x.Key, ",", x.Value));

        string parametres = Symbols + "|" + string.Join(",", list) + "|" + string.Join(";", pairs);
        
        Debug.Log(parametres);

        Save.SaveData(BaseCode.Encode(parametres));
    }
    
}
