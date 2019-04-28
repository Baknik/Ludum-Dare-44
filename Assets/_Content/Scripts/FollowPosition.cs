using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public Vector2Reference PositionToFollow;
    public BoolReference InstantFollow;
    public FloatReference FollowSpeed;
    public Vector3Reference Offset;

    public BoolReference UseLateUpdate;
    public BoolReference UseFixedUpdate;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (!this.UseFixedUpdate.Value && !this.UseLateUpdate.Value)
        {
            if (this.InstantFollow.Value)
            {
                this.transform.position = (Vector3)this.PositionToFollow.Value + this.Offset.Value;
            }
            else
            {
                this.transform.position = Vector3.Lerp(this.transform.position, (Vector3)this.PositionToFollow.Value + this.Offset.Value, Time.deltaTime * this.FollowSpeed.Value);
            }
        }
    }

    void LateUpdate()
    {
        if (!this.UseFixedUpdate.Value && this.UseLateUpdate.Value)
        {
            if (this.InstantFollow.Value)
            {
                this.transform.position = (Vector3)this.PositionToFollow.Value + this.Offset.Value;
            }
            else
            {
                this.transform.position = Vector3.Lerp(this.transform.position, (Vector3)this.PositionToFollow.Value + this.Offset.Value, Time.deltaTime * this.FollowSpeed.Value);
            }
        }
    }

    void FixedUpdate()
    {
        if(this.UseFixedUpdate.Value && !this.UseLateUpdate.Value)
        {
            if (this.InstantFollow.Value)
            {
                this.transform.position = (Vector3)this.PositionToFollow.Value + this.Offset.Value;
            }
            else
            {
                this.transform.position = Vector3.Lerp(this.transform.position, (Vector3)this.PositionToFollow.Value + this.Offset.Value, Time.fixedDeltaTime * this.FollowSpeed.Value);
            }
        }
    }
}
