using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public FloatReference DegreesPerSecond;

    void Start()
    {
        
    }
    
    void Update()
    {
        this.transform.Rotate(0, 0, this.DegreesPerSecond.Value * Time.deltaTime);
    }
}
