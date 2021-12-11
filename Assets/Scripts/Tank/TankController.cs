using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class TankController : MonoBehaviour
{
    public float mSpeed;

    private PlayerInput mPlayerInput;
    private Vector2 mMovement;

    private void Awake()
    {
        mPlayerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        transform.position += new Vector3(mMovement.x, 0f, mMovement.y) * Time.deltaTime * mSpeed;
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        mMovement = value.ReadValue<Vector2>();

    }

    public void OnFire(InputAction.CallbackContext value)
    {

    }

}
