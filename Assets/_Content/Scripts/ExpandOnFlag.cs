using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandOnFlag : MonoBehaviour
{
    public BoolReference ExpandOnFlagRef;

    void Start()
    {
        this.transform.localScale = Vector3.zero;
    }
    
    void Update()
    {
        this.transform.localScale = this.ExpandOnFlagRef.Value ? Vector3.one : Vector3.zero;
    }
}
