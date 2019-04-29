using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSystem : MonoBehaviour
{
    public AudioClip RobotFireClip;
    public AudioClip RobotSoftHit;
    public AudioClip TurretFireClip;
    public AudioClip RobotDeathClip;
    public AudioClip RobotRechargeClip;
    public AudioClip WinClip;
    public AudioClip DoorUnlockedClip;

    private AudioSource audioSource;

    void Awake()
    {
        this.audioSource = this.GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void HandleRobotFire()
    {
        this.audioSource.PlayOneShot(this.RobotFireClip);
    }

    public void HandleSoftHit()
    {
        this.audioSource.PlayOneShot(this.RobotSoftHit);
    }

    public void HandleTurretFire()
    {
        this.audioSource.PlayOneShot(this.TurretFireClip);
    }

    public void HandleRobotDeath()
    {
        this.audioSource.PlayOneShot(this.RobotDeathClip);
    }

    public void HandleRobotRecharge()
    {
        this.audioSource.PlayOneShot(this.RobotRechargeClip);
    }

    public void HandleTrialCompleted()
    {
        this.audioSource.PlayOneShot(this.WinClip);
    }

    public void HandleDoorUnlocked()
    {
        this.audioSource.PlayOneShot(this.DoorUnlockedClip);
    }
}
