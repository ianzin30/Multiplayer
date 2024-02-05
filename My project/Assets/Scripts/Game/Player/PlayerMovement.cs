using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;
    [SerializeField]
    private float _rotationSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private float _accelerationDelay = 0.1f;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // updated every frame
    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        // smoothing is used to avoid sudden movements
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput, ref _movementInputSmoothVelocity, _accelerationDelay);
        _rigidbody.velocity = _smoothedMovementInput * _speed; // updates velocity
    }

    // updates whenever the player object moves
    private void OnMove(InputValue inputValue) {
        _movementInput = inputValue.Get<Vector2>();
    }
    
    private void RotateInDirectionOfInput() {
        // check if the player is moving
        if (_movementInput != Vector2.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }
    
}
