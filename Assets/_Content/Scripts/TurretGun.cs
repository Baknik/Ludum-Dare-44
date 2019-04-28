using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : MonoBehaviour
{
    public Projectile TurretProjectile;

    public FloatReference AggroRange;
    public FloatReference ProjectileSpeed;
    public FloatReference FireRate;
    public Vector2Reference ProjectileSpawnOffset;

    public Vector2Reference TargetPosition;

    void Start()
    {
        this.InvokeRepeating("Fire", this.FireRate.Value, this.FireRate.Value);
    }
    
    void Update()
    {
        
    }

    public void Fire()
    {
        if (Vector2.Distance(this.transform.position, this.TargetPosition.Value) <= this.AggroRange.Value)
        {
            Projectile turretProjectile = Instantiate<Projectile>(this.TurretProjectile, this.transform.TransformPoint(this.ProjectileSpawnOffset.Value), Quaternion.identity);
            turretProjectile.SetInitialVelocity(this.transform.TransformVector(Vector2.right) * this.ProjectileSpeed.Value);
        }
    }
}
