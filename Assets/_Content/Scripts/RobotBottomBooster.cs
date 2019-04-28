using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RobotBottomBooster : MonoBehaviour
{
    public FloatReference IdleStartLifetime;
    public FloatReference BoostingStartLifetime;
    public FloatReference StartLifetimeGravity;

    public BoolReference RobotBoosting;

    private ParticleSystem particleSystem;

    void Awake()
    {
        this.particleSystem = this.GetComponent<ParticleSystem>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        var main = this.particleSystem.main;
        main.startLifetime = new ParticleSystem.MinMaxCurve(Mathf.Lerp(main.startLifetime.constant, this.RobotBoosting.Value ? this.BoostingStartLifetime.Value : this.IdleStartLifetime.Value, Time.deltaTime * this.StartLifetimeGravity.Value));
    }
}
