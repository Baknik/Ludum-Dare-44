using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public BoolReference Explode;
    public Explosion Explosion;

    public GameEvent SoftHit;

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.SoftHit.Raise();

        if (this.Explode.Value)
        {
            Instantiate(this.Explosion, this.transform.position, Quaternion.identity);
        }

        GameObject.Destroy(this.gameObject);
    }
}
