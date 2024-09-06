using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Manager : MonoBehaviour
{
    public ParticleSystem wind_system;
    public Camera mainCamera;
    private ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime;
    // Start is called before the first frame update
    void Start()
    {
        wind_system = gameObject.GetComponent<ParticleSystem>();
        velocityOverLifetime = wind_system.velocityOverLifetime;
        velocityOverLifetime.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToCamera = (mainCamera.transform.position - wind_system.transform.position).normalized;

        // Align the particle system's velocity to move towards the camera
        velocityOverLifetime.x = directionToCamera.x * 5f;  // Adjust the multiplier to control speed
        velocityOverLifetime.y = directionToCamera.y * 5f;  // Adjust the multiplier to control speed
        velocityOverLifetime.z = directionToCamera.z * 5f;
    }
}
