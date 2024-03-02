using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

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
    private float _accelerationDelay = 0.1f;
    private Camera _camera;
    [SerializeField]
    private float _screenBorder;
    [SerializeField]
    private Tilemap _tilemap;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _animator = GetComponent<Animator>();
    }

    // updated every frame
    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
        SetAnimation();
    }

    private void SetPlayerVelocity()
    {
        // smoothing is used to avoid sudden movements
        _smoothedMovementInput = Vector2.SmoothDamp(_smoothedMovementInput, _movementInput, ref _movementInputSmoothVelocity, _accelerationDelay);
        _rigidbody.velocity = _smoothedMovementInput * _speed; // updates velocity
        //PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen()
    {
        // gets the current tile position and sums with the velocity to check if the next tile is a wall
        Vector3Int playerTilePosition = _tilemap.WorldToCell(transform.position);

        if (!_tilemap.HasTile(playerTilePosition + new Vector3Int(1, 0, 0)) && _rigidbody.velocity.x > 0 || !_tilemap.HasTile(playerTilePosition + new Vector3Int(-1, 0, 0)) && _rigidbody.velocity.x < 0)
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if (!_tilemap.HasTile(playerTilePosition + new Vector3Int(0, 1, 0)) && _rigidbody.velocity.y > 0 || !_tilemap.HasTile(playerTilePosition + new Vector3Int(0, -1, 0)) && _rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }

        if (!_tilemap.HasTile(playerTilePosition + new Vector3Int(1, 1, 0)) && _rigidbody.velocity.x > 0 && _rigidbody.velocity.y > 0 || !_tilemap.HasTile(playerTilePosition + new Vector3Int(-1, -1, 0)) && _rigidbody.velocity.x < 0 && _rigidbody.velocity.y < 0 || !_tilemap.HasTile(playerTilePosition + new Vector3Int(1, -1, 0)) && _rigidbody.velocity.x > 0 && _rigidbody.velocity.y < 0 || !_tilemap.HasTile(playerTilePosition + new Vector3Int(-1, 1, 0)) && _rigidbody.velocity.x < 0 && _rigidbody.velocity.y > 0)
        {
            _rigidbody.velocity = new Vector2(0, 0);
        }

    }

    // updates whenever the player object moves
    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void RotateInDirectionOfInput()
    {
        // check if the player is moving
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }

    private void SetAnimation()
    {
        if (_movementInput != Vector2.zero)
        {
            _animator.SetBool("isMoving", true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
    }

}
