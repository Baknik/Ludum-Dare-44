using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void SetInitialVelocity(Vector2 velocity)
    {
        this.rigidbody2D.velocity = velocity;
    }
}
