using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    public List<Transform> bla;
    [SerializeField]
    public List<int> k;


    private void Start()
    {

        ListData la = new ListData();
        ListData lb = new ListData();
        SaveLoadManager.LoadTemporary(ref la, ref lb, "bla");
        la.Fill(lb.elems);
        la.Extract(bla);

        //string[] param = BaseCode.Decode(Load.LoadData<string>(ref Symbols)).Split('|');
        //Vector3 b=new Vector3();
        //LoadManager.Load(ref b, "lm");
        //Debug.Log(b);

        //Symbols = param[0];

        //if (param.Length > 1 && param[1] != "") //List
        //{
        //    string[] ListElems = param[2].Split(',');
        //    for (int i = 0; i < ListElems.Length; i++)
        //    {
        //        string[] values = ListElems[i].Split(',');
        //        list.Add(new Vector3());
        //    }
        //}

        //if (param.Length > 2&param[2]!="") //Dictionary
        //{
        //    string[] dictionaryElems = param[2].Split(';');
        //    for (int i = 0; i < dictionaryElems.Length; i++)
        //    {
        //        string[] values = dictionaryElems[i].Split(',');
        //        dictionary.Add(values[0], int.Parse(values[1]));

        //    }
        //}
    }
    private void OnApplicationQuit()
    {
 
        ListData l = new ListData();;
        l.Fill(bla, k);
        SaveLoadManager.SaveTemporary(l, "bla");
        //SaveLoadManager.Save(new Vec3(bla[0].x, bla[0].y,bla[0].z), 0, "bla");
        //SaveLoadManager.Save(new Vec3(bla[1].x, bla[1].y, bla[1].z), 1, "bla");

    }
    
}
