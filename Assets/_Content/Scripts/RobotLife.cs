using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLife : MonoBehaviour
{
    public Explosion RobotExplosion;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void HandleRobotDeath()
    {
        Instantiate(this.RobotExplosion, this.transform.position, Quaternion.identity);

        GameObject.Destroy(this.gameObject);
    }
}
