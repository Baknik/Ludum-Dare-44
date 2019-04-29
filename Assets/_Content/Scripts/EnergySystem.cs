using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public FloatClampedVariable RobotEnergy;
    public BoolReference RobotAlive;
    public GameEvent RobotDeath;

    private bool deathEventRaised;

    void Start()
    {
        this.RobotEnergy.Value = this.RobotEnergy.MaxValue.Value;
        this.deathEventRaised = false;
    }
    
    void Update()
    {
        if (this.RobotEnergy.Value > 0f)
        {
            this.deathEventRaised = false;

        }

        this.RobotAlive.Value = !this.deathEventRaised;
    }

    public void HandleRobotHit(float damage)
    {
        this.RobotEnergy.Value -= damage;

        if (this.RobotEnergy.Value <= 0f)
        {
            this.RobotEnergy.Value = 0f;
            if (!this.deathEventRaised)
            {
                this.deathEventRaised = true;
                this.RobotDeath.Raise();
            }
        }
    }
}
