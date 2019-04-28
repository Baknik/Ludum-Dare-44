using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RobotBackBooster : MonoBehaviour
{
    public BoolReference RobotSprinting;
    public FloatReference RobotFacingDirection;

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
        var emission = this.particleSystem.emission;
        emission.enabled = this.RobotSprinting.Value;

        var velocityOverLifetime = this.particleSystem.velocityOverLifetime;
        velocityOverLifetime.x = Mathf.Abs(velocityOverLifetime.x.constant) * this.RobotFacingDirection.Value * -1f;
    }
}
