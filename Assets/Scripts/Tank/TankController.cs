using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class TankController : MonoBehaviour
{
    public float mSpeed;
    public float mRotationAngle;

    private PlayerInput mPlayerInput;
    private Vector2 mMovement;

    private void Awake()
    {
        mPlayerInput = GetComponent<PlayerInput>();
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

    }

}
