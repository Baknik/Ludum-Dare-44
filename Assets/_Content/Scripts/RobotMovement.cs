using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RobotMovement : MonoBehaviour
{
    public FloatReference RobotMovementSpeed;
    public FloatReference RobotBoostImpulseForce;
    public FloatReference RobotBoostForce;
    public FloatReference GroundTestDistance;
    public FloatReference RobotSprintSpeed;
    public LayerMask GroundLayerMask;

    public Vector2Reference RobotPosition;
    public FloatClampedVariable RobotMovementDirection;
    public FloatClampedVariable RobotFacingDirection;
    public Vector2Reference RobotVelocity;
    public BoolReference RobotBoosting;
    public BoolReference RobotGrounded;
    public BoolReference RobotSprinting;

    private Rigidbody2D rigidbody2D;

    void Awake()
    {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        this.RobotPosition.Value = this.transform.position;

        // Ground Test
        Debug.DrawRay(this.transform.position, Vector2.down * this.GroundTestDistance.Value, Color.green);
        RaycastHit2D groundTestHit = Physics2D.Raycast(this.transform.position, Vector2.down, this.GroundTestDistance.Value, this.GroundLayerMask);
        this.RobotGrounded.Value = (groundTestHit.collider != null);
    }

    void FixedUpdate()
    {
        Vector2 velocity = new Vector2(this.RobotMovementDirection.Value * this.RobotMovementSpeed.Value, this.rigidbody2D.velocity.y);
        if (this.RobotSprinting.Value)
        {
            velocity += (Vector2.right * this.RobotFacingDirection.Value * this.RobotSprintSpeed.Value);
        }
        this.rigidbody2D.velocity = velocity;

        this.RobotVelocity.Value = this.rigidbody2D.velocity;

        if (this.RobotBoosting.Value)
        {
            this.rigidbody2D.AddForce(Vector2.up * this.RobotBoostForce.Value, ForceMode2D.Force);
        }
    }

    public void HandleRobotStartBoosting()
    {
        this.rigidbody2D.AddForce(Vector2.up * this.RobotBoostImpulseForce.Value, ForceMode2D.Impulse);
    }
}
