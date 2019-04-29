using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGun : MonoBehaviour
{
    public Projectile RobotProjectile;

    public FloatReference ProjectileSpeed;
    public Vector2Reference ProjectileSpawnOffset;

    public Vector2Reference RobotAimDirection;

    void Start()
    {
        
    }
    
    void Update()
    {
        this.RobotAimDirection.Value = this.transform.TransformVector(Vector2.right);
    }

    public void HandleRobotFire()
    {
        Projectile robotProjectile = Instantiate<Projectile>(this.RobotProjectile, this.transform.TransformPoint(this.ProjectileSpawnOffset.Value), this.transform.rotation);
        robotProjectile.SetInitialVelocity(this.transform.TransformVector(Vector2.right) * this.ProjectileSpeed.Value);
    }
}
