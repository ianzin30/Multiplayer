using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    private bool _fireContinuously;
    [SerializeField]
    private Transform _gunOffset;
    [SerializeField]
    private float _shotDelay;
    [SerializeField]
    private float _shotDelayBase;
    private float _lastFireTime;
    // Update is called once per frame
    [SerializeField] private AudioSource _shootSoundEffect;
    void Update()
    {
        if (_fireContinuously)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _shotDelay)
            {
                FireBullet();

                _lastFireTime = Time.time;
            }
        }
    }

    private void OnFire(InputValue inputvalue)
    {
        _fireContinuously = inputvalue.isPressed;

    }

    private void FireBullet()
    {
        _shootSoundEffect.Play();
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        rigidbody.velocity = _bulletSpeed * transform.up;
    }

    public void IncreaseFireRate(float fireUpAmount, float fireUpDuration)
    {
        _shotDelay = _shotDelay / fireUpAmount;
        StartCoroutine(ResetFireRate(fireUpDuration));
    }

    private IEnumerator ResetFireRate(float fireUpDuration)
    {
        yield return new WaitForSeconds(fireUpDuration);
        _shotDelay = _shotDelayBase;
    }
}
