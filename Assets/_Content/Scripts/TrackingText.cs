using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TrackingText : MonoBehaviour
{
    public FloatReference TrackedValue;

    private Text TextField;

    void Awake()
    {
        this.TextField = this.GetComponent<Text>();
    }
    
    void Update()
    {
        this.TextField.text = ((int)this.TrackedValue.Value).ToString();
    }
}
