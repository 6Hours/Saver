using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeArrow : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        Color color = new Vector4(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), 1);
        GetComponent<Renderer>().material.color = color;
    }
}
