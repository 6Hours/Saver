using System;
using UnityEngine;

public class TimeMover : MonoBehaviour
{
    public string TimeType;
    // Update is called once per frame
    void Update()
    {
        if (TimeType.ToLower() == "second")
            transform.rotation = Quaternion.Euler(0, 0, DateTime.Now.Second * -360f / 60f);
        if (TimeType.ToLower() == "minute")
            transform.rotation = Quaternion.Euler(0, 0, DateTime.Now.Minute * -360f / 60f + DateTime.Now.Second * -360f / 3600f);
        if (TimeType.ToLower() == "hour")
            transform.rotation = Quaternion.Euler(0, 0, DateTime.Now.Hour * -360f / 12f+ DateTime.Now.Minute * -360f / 720f + DateTime.Now.Second * -360f / 3600f);
    }
}
