using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawnBullet;

    public float speed;

    private bool _isJump;
    private bool _isForce;
    private bool _isFire;
    private Vector3 _direction;

    private void Awake()
    {
        _isFire = false;
    }

    
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _isFire = true;

        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _isForce = Input.GetButton("Force");
        _isJump = Input.GetButton("Jump");

    }

    private void FixedUpdate()
    {
        if (_isFire)
            Fire();

        Move();
        //Jump();

    }

    private void Jump()
    {
        float height = _isJump ? _direction.y = 1 : _direction.y = 0;
        transform.Translate(_direction * height);
    }

    private void Move()
    {
        float s = (_isForce) ? speed * 2f : speed;

        transform.Translate(_direction.normalized * s * Time.fixedDeltaTime);
    }

    private void Fire()
    {
        GameObject bullet = GameObject.Instantiate(_bulletPrefab, _spawnBullet.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().Init(3f);

        _isFire = false;
    }

}
