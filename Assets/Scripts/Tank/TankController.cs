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
    public float mTurretRotationSpeed = 0f;
    public Transform mShootingPoint;

    private PlayerInput mPlayerInput;
    private Vector2 mMovement;
    private Vector2 mMousePosition;
    private Transform mTurret;

    private ParticleSystem mShootingPS;
    private Plane mPlane = new Plane(Vector3.up, 0f);

    private void Awake()
    {
        mPlayerInput = GetComponent<PlayerInput>();
        mShootingPS = mShootingPoint.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        mTurret = transform.Find("Disc");

        // Setting tank in grid
        //GameManager.Instance.GetGrid().SetElement(this.gameObject,
        //    transform.position.x, transform.position.z);
    }
    private void Update()
    {
        // Move Forward/Backward
        transform.position += transform.forward * mMovement.y * Time.deltaTime * mSpeed;

        // Rotate
        transform.Rotate(Vector3.up, mRotationAngle * mMovement.x * Time.deltaTime);

        // Turret Rotation
        RotateFollowingCursor(mMousePosition);
        /*Quaternion lookAt = Quaternion.Euler(0f, mTurretRotation, 0f);
        mTurret.rotation = Quaternion.Slerp(
            mTurret.rotation, lookAt, mTurretRotationSpeed * Time.deltaTime);*/
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        mMovement = value.ReadValue<Vector2>();

    }

    public void OnFire(InputAction.CallbackContext value)
    {
        Shoot();
    }

    public void OnTurretRotation(InputAction.CallbackContext value)
    {
        mMousePosition = value.ReadValue<Vector2>();
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

    private void RotateFollowingCursor(Vector2 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        float distance;
        if (mPlane.Raycast(ray, out distance))
        {
            Vector3 lookAtPosition = ray.GetPoint(distance);

            Quaternion lookAt = Quaternion.LookRotation(
                new Vector3(lookAtPosition.x, transform.position.y, lookAtPosition.z) - transform.position);
            mTurret.rotation = Quaternion.Slerp(mTurret.rotation, lookAt, Time.deltaTime * mTurretRotationSpeed);
        }
    }

}
