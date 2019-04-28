using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePosition : MonoBehaviour
{
    public FloatReference RotationSpeed;
    public BoolReference UseAngleLimit;
    public FloatReference MinAngleLimit;
    public FloatReference MaxAngleLimit;
    public BoolReference LockRotationFlag;
    public FloatReference MaxDistance;

    public Vector2Reference TargetPosition;
    public BoolReference ReverseBasedOnScale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.LockRotationFlag.Value && Vector2.Distance(this.transform.position, this.TargetPosition.Value) <= this.MaxDistance.Value)
        {
            Vector2 vectorToTarget = this.TargetPosition.Value - (Vector2)this.transform.position;
            if (this.ReverseBasedOnScale.Value)
            {
                vectorToTarget = new Vector2(vectorToTarget.x * this.transform.localScale.x, vectorToTarget.y);
            }
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            if (!this.UseAngleLimit.Value ||
                (angle >= MinAngleLimit.Value && angle <= MaxAngleLimit.Value))
            {
                Quaternion q = Quaternion.AngleAxis(angle, (this.ReverseBasedOnScale.Value) ? Vector3.back : Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * this.RotationSpeed.Value);
            }
            Debug.DrawRay(this.transform.position, vectorToTarget, Color.blue);
        }
    }
}
