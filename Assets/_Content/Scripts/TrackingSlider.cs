using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.UI.Slider))]
public class TrackingSlider : MonoBehaviour
{
    public FloatReference StartValue;

    public FloatClampedVariable TrackedValue;

    private UnityEngine.UI.Slider slider;

    void Awake()
    {
        this.slider = this.GetComponent<UnityEngine.UI.Slider>();
    }

    void Start()
    {
        this.slider.minValue = this.TrackedValue.MinValue.Value;
        this.slider.maxValue = this.TrackedValue.MaxValue.Value;
        this.slider.value = this.StartValue.Value;
    }
    
    void Update()
    {
        this.slider.value = this.TrackedValue.Value;
    }
}
