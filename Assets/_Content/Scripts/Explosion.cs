using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Explosion : MonoBehaviour
{
    public IntReference NumBurstParticles;

    private ParticleSystem particleSystem;

    void Awake()
    {
        this.particleSystem = this.GetComponent<ParticleSystem>();
    }

    void Start()
    {
        this.particleSystem.Emit(this.NumBurstParticles.Value);
        GameObject.Destroy(this.gameObject, 2f);
    }
}
