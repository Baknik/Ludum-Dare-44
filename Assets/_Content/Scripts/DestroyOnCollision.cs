using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public BoolReference Explode;
    public Explosion Explosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.Explode.Value)
        {
            Instantiate(this.Explosion, this.transform.position, Quaternion.identity);
        }

        GameObject.Destroy(this.gameObject);
    }
}
