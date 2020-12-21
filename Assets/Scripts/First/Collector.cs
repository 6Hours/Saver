using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Vec3
{
    public float x, y, z;

    public Vec3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Vector3 ToVector3()
    {
        return new Vector3(this.x, this.y, this.z);
    }
}
[System.Serializable]
public struct TransformData
{
    [SerializeField]
    public Vec3 position;
    [SerializeField]
    public Vec3 direction;
    [SerializeField]
    public int index;

    public TransformData(Vector3 vPos,Vector3 vDir, int i)
    {
        this.position = new Vec3(vPos.x, vPos.y, vPos.z);
        this.direction = new Vec3(vDir.x, vDir.y, vDir.z);
        this.index = i;
    }
}
[System.Serializable]
public struct ListData
{
    [SerializeField]
    public List<TransformData> elems;

    public void Fill(List<Transform> _list, List<int> indexes)
    {
        if (this.elems == null) this.elems = new List<TransformData>();
        for (int i = 0; i < _list.Count; i++)
        {
            bool have = false;
            for (int j = 0; j < this.elems.Count; j++)
            {
                if (indexes[i] == this.elems[j].index)
                {
                    this.elems[j] = new TransformData(_list[i].position, _list[i].rotation.eulerAngles, indexes[i]);
                    have = true;
                }
            }
            if (!have) this.elems.Add(new TransformData(_list[i].position, _list[i].rotation.eulerAngles, indexes[i]));
        }           
    }
    public void Fill(List<TransformData> _list)
    {
        if (this.elems == null) this.elems = new List<TransformData>();
        for (int i = 0; i < _list.Count; i++)
        {
            bool have = false;
            for (int j = 0; j < this.elems.Count; j++)
            {
                if (_list[i].index == this.elems[j].index)
                {
                    this.elems[j] = new TransformData(_list[i].position.ToVector3(), _list[i].direction.ToVector3(), _list[i].index);
                    have = true;
                }
            }
            if (!have) this.elems.Add(new TransformData(_list[i].position.ToVector3(), _list[i].direction.ToVector3(), _list[i].index));
        }
    }
    public void Extract(List<Transform> _list) //Заполнение данными списка _list существующих (не null) элементов  Transform
    {
        for(int i = 0; i<this.elems.Count;i++)
        {
            _list[this.elems[i].index].position = this.elems[i].position.ToVector3();
            _list[this.elems[i].index].rotation = Quaternion.Euler(this.elems[i].direction.ToVector3());
        }
    }
}

[System.Serializable]
public abstract class Collector : MonoBehaviour
{
    public virtual void Extract()
    { }
}

//Childs
[System.Serializable]
public class Data: Collector
{
    //поля
    public Data()
    {
        //В конструкторе сбор данных в поля
    }
    public override void Extract()
    {
        //Тут извлечение данных в нужные скрипты
    }
}
[System.Serializable]
public class Settings : Collector
{
    //поля
    public Settings()
    {
        //В конструкторе сбор данных в поля
    }
    public override void Extract()
    {
        //Тут извлечение данных в нужные скрипты
    }
}
[System.Serializable]
public class Mission : Collector
{
    //поля
    public Mission()
    {
        //В конструкторе сбор данных в поля
    }
    public override void Extract()
    {
        //Тут извлечение данных в нужные скрипты
    }
}
