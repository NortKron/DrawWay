using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Transform Begin;
    public Transform End;

    void Awake()
    {
        Begin = transform.Find("ObjectBegin").gameObject.transform;
        End = transform.Find("ObjectEnd").gameObject.transform;        
    }
}
