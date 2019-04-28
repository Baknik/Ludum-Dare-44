using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class InputSystem : MonoBehaviour
{
    public FloatReference BoostInitialEnergyCost;
    public FloatReference BoostEnergyCostPerSecond;
    public FloatReference SprintEnergyCostPerSecond;
    public FloatReference FireEnergyCost;

    public FloatClampedVariable RobotMovementDirection;
    public Vector2Reference PointerWorldPosition;
    public BoolReference RobotBoosting;
    public BoolReference RobotSprinting;
    public BoolReference RobotFiring;
    public FloatReference RobotEnergy;
    public BoolReference RobotGrounded;

    public GameEvent RobotStartBoosting;
    public GameEvent RobotFire;

    private Player player;

    void Awake()
    {
        player = Rewired.ReInput.players.GetPlayer(0);
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        this.RobotMovementDirection.Value = player.GetAxis("Move Horizontal");

        this.PointerWorldPosition.Value = Camera.main.ScreenToWorldPoint(ReInput.controllers.Mouse.screenPosition);

        // Boost event
        if (player.GetButtonDown("Boost") &&
            this.RobotEnergy.Value >= this.BoostInitialEnergyCost.Value &&
            this.RobotGrounded.Value)
        {
            this.RobotEnergy.Value -= this.BoostInitialEnergyCost.Value;
            this.RobotStartBoosting.Raise();
        }

        // Ongoing boost
        if (player.GetButton("Boost") &&
            this.RobotEnergy.Value >= this.BoostEnergyCostPerSecond.Value &&
            !this.RobotGrounded.Value)
        {
            this.RobotEnergy.Value -= (this.BoostEnergyCostPerSecond.Value * Time.deltaTime);
            this.RobotBoosting.Value = true;
        }
        else
        {
            this.RobotBoosting.Value = false;
        }

        // Fire event
        if (player.GetButtonDown("Fire") &&
            this.RobotEnergy.Value >= this.FireEnergyCost.Value)
        {
            this.RobotEnergy.Value -= this.FireEnergyCost.Value;
            this.RobotFire.Raise();
        }

        // Ongoing firing
        this.RobotFiring.Value = player.GetButton("Fire");

        // Ongoing sprinting
        if (player.GetButton("Sprint") &&
            this.RobotEnergy.Value >= this.SprintEnergyCostPerSecond.Value)
        {
            this.RobotEnergy.Value -= (this.SprintEnergyCostPerSecond.Value * Time.deltaTime);
            this.RobotSprinting.Value = true;
        }
        else
        {
            this.RobotSprinting.Value = false;
        }
    }
}
