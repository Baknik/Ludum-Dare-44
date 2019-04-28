using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScaleToFace : MonoBehaviour
{
    public Vector2Reference TargetPosition;
    public FloatReference RobotFacingDirection;

    void Start()
    {
        
    }
    
    void Update()
    {
        float scaleMultiplier = (this.TargetPosition.Value.x >= this.transform.position.x) ? 1f : -1f;
        this.transform.localScale = new Vector2(scaleMultiplier, this.transform.localScale.y);

        this.RobotFacingDirection.Value = scaleMultiplier;
    }
}
