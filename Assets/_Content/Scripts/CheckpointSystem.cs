using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public Transform Robot;

    public Vector2Reference Checkpoint;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void HandleRobotDeath()
    {
        Invoke("Respawn", 2f);
    }

    public void Respawn()
    {
        Instantiate(this.Robot, this.Checkpoint.Value, Quaternion.identity);
    }
}
