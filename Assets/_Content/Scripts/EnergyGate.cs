using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyGate : MonoBehaviour
{
    public FloatReference EnergyCost;

    public Transform Barrier;
    public TextMesh Text;
    public FloatClampedVariable RobotEnergy;

    public GameEvent DoorUnlocked;

    void Start()
    {
        this.Text.text = ((int)this.EnergyCost.Value).ToString();
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.Barrier != null &&
                this.Text != null &&
                this.RobotEnergy.Value >= this.EnergyCost.Value)
            {
                this.DoorUnlocked.Raise();
                this.RobotEnergy.Value -= this.EnergyCost.Value;
                GameObject.Destroy(this.Barrier.gameObject);
                GameObject.Destroy(this.Text.gameObject);
            }
        }
    }
}
