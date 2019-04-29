using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SwapTextOnFlag : MonoBehaviour
{
    public BoolReference Flag;

    public StringReference TrueText;
    public StringReference FalseText;

    private Text text;

    void Awake()
    {
        this.text = this.GetComponent<Text>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        this.text.text = this.Flag.Value ? this.TrueText.Value : this.FalseText.Value;
    }
}
