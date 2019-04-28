using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamageEventOnCollision : MonoBehaviour
{
    public StringReference Tag;
    public FloatGameEvent DamageEvent;
    public FloatReference Damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == this.Tag.Value)
        {
            this.DamageEvent.Raise(this.Damage.Value);
        }
    }
}
