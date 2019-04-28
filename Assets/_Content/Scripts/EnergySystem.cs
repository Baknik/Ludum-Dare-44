using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public FloatReference StartEnergy;

    public FloatReference RobotEnergy;

    void Start()
    {
        this.RobotEnergy.Value = this.StartEnergy.Value;
    }
    
    void Update()
    {
        
    }

    public void HandleRobotHit(float damage)
    {
        this.RobotEnergy.Value -= damage;
    }
}
