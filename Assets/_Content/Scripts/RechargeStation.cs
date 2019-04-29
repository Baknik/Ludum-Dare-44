using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeStation : MonoBehaviour
{
    public Vector2Reference CheckpointLocalPosition;
    public BoolReference IsStart;

    public FloatClampedVariable RobotEnergy;

    public Vector2Reference Checkpoint;
    public GameEvent RobotRecharge;

    void Start()
    {
        if (this.IsStart.Value)
        {
            this.Checkpoint.Value = this.transform.TransformPoint(this.CheckpointLocalPosition.Value);
        }
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.RobotRecharge.Raise();
            this.RobotEnergy.Value = this.RobotEnergy.MaxValue.Value;
            this.Checkpoint.Value = this.transform.TransformPoint(this.CheckpointLocalPosition.Value);
        }
    }
}
