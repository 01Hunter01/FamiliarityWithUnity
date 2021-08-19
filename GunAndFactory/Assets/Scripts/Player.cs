using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage, IHealthAmmo
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawnBullet;
    [SerializeField] private float _hp = 150;
    [SerializeField] private float _ammo = 30;

    public float speed;
    public float speedRotate;
    public float heightJump;

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
        Jump();

        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.fixedDeltaTime * speedRotate, 0);

    }

    private void Jump()
    {
        float height = _isJump ? _direction.y = heightJump : _direction.y = 0;
        transform.Translate(_direction * height * Time.fixedDeltaTime);
    }

    private void Move()
    {
        float s = (_isForce) ? speed * 2f : speed;

        transform.Translate(_direction.normalized * s * Time.fixedDeltaTime);
    }

    private void Fire()
    {
        GameObject bullet = GameObject.Instantiate(_bulletPrefab, _spawnBullet.position, Quaternion.identity);

        bullet.GetComponent<Bullet>().Init(10f, 4f);

        _isFire = false;
    }

    public void Boom(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            Destroy(gameObject);
    }

    public void Hit(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void HitTrapFloor(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
            Destroy(gameObject);
    }

    public void HitTrapWall(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
            Destroy(gameObject);
    }



    public void Health(float health)
    {
        _hp += health;
    }

    public void Ammo(float ammo)
    {
        _ammo += ammo;
    }

    
}
