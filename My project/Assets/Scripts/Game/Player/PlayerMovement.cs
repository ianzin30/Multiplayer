using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private float _accelerationDelay = 0.1f;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput, ref _movementInputSmoothVelocity, _accelerationDelay);
        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }

    // updates whenever the player object moves
    private void OnMove(InputValue inputValue) {
        _movementInput = inputValue.Get<Vector2>();
    }
    
    
}
