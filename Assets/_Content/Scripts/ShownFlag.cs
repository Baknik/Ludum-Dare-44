using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShownFlag : MonoBehaviour
{
    public BoolReference Flag;

    void Start()
    {
        
    }
    
    void Update()
    {
        this.GetComponent<Renderer>().enabled = this.Flag.Value;
    }
}
