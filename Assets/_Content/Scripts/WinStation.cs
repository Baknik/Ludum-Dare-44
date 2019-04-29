using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStation : MonoBehaviour
{
    public BoolReference TrialComplete;

    public GameEvent TrialCompleted;

    private Collider2D collider;

    void Awake()
    {
        this.collider = this.GetComponent<Collider2D>();
    }

    void Start()
    {
        this.TrialComplete.Value = false;
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.TrialComplete.Value = true;
            this.collider.enabled = false;
            this.TrialCompleted.Raise();
        }
    }
}
