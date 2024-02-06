using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;
    [SerializeField]
    private float _rotationSpeed = 720;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private PhotonView _photonView;
    private float _accelerationDelay = 0.1f;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _photonView = GetComponent<PhotonView>();
    }

    // Updated every frame
    private void FixedUpdate()
    {
        // Only control the player if it's the local player's character
        if (_photonView.IsMine)
        {
            SetPlayerVelocity();
            RotateInDirectionOfInput();
        }
    }

    private void SetPlayerVelocity()
    {
        // Smoothing is used to avoid sudden movements
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput, ref _movementInputSmoothVelocity, _accelerationDelay);
        _rigidbody.velocity = _smoothedMovementInput * _speed; // Updates velocity
    }

    // Updates whenever the player object moves
    private void OnMove(InputValue inputValue)
    {
        // Only process input if it's the local player's character
        if (_photonView.IsMine)
        {
            _movementInput = inputValue.Get<Vector2>();
        }
    }

    private void RotateInDirectionOfInput()
    {
        // Check if the player is moving
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }
}
