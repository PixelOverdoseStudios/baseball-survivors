using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncherWeapon : MonoBehaviour
{
    [SerializeField] private GameObject ballLauncherObject;
    [SerializeField] private float spawningCooldown;
    private float cooldownTimer;
    public float turretLifeTime;
    public float detectionRadius;
    public float projectileDamage;
    public float projectileCooldown;
    public float projectileSpeed;

    private void Start()
    {
        cooldownTimer = spawningCooldown - 0.5f;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer >= spawningCooldown)
        {
            Instantiate(ballLauncherObject, transform.position, Quaternion.identity);
            cooldownTimer = 0;
        }
    }
}
