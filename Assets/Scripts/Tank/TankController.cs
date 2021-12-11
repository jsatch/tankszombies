using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class TankController : MonoBehaviour
{
    public float mSpeed;
    public float mRotationAngle;
    public float mShootingRange = 100f;
    public Transform mShootingPoint;

    private PlayerInput mPlayerInput;
    private Vector2 mMovement;

    private ParticleSystem mShootingPS;

    private void Awake()
    {
        mPlayerInput = GetComponent<PlayerInput>();
        mShootingPS = mShootingPoint.Find("MuzzleFlash").GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        // Move Forward/Backward
        transform.position += transform.forward * mMovement.y * Time.deltaTime * mSpeed;

        // Rotate
        transform.Rotate(Vector3.up, mRotationAngle * mMovement.x * Time.deltaTime);
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        mMovement = value.ReadValue<Vector2>();

    }

    public void OnFire(InputAction.CallbackContext value)
    {
        Shoot();
    }

    private void Shoot()
    {
        mShootingPS.Play();
        if (Debug.isDebugBuild)
        {
            Debug.DrawRay(mShootingPoint.position, mShootingPoint.forward * mShootingRange, Color.red, 0.5f);
        }
        
        if (Physics.Raycast(mShootingPoint.position, mShootingPoint.forward, out RaycastHit hit, mShootingRange))
        {
            Debug.Log("Dio en algo");
        }
    }

}
