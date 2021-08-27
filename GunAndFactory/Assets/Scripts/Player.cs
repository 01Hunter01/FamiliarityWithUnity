using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage, IHealthAmmo
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawnBullet;
    [SerializeField] private float _hp = 150;
    [SerializeField] private float _ammo = 30;

    private Rigidbody _rb;

    private Dictionary<string, int> _inventory;

    

    public float speed;
    public float speedRotate;
    public float heightJump;

    private bool _isJump;
    private bool _isForce;
    private bool _isFire;
    private bool _isGround;
    private Vector3 _direction;

    private void Awake()
    {
        _isFire = false;
        _inventory = new Dictionary<string, int>();
        _rb = GetComponent<Rigidbody>();
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
        _isJump = Input.GetButton("Jump") && _isGround;
    }

    private void FixedUpdate()
    {
        if (_isFire)
            Fire();

        Move();
        Jump();
        
        transform.Rotate(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0);
        //_rb.AddTorque(0, Input.GetAxis("Mouse X") * speedRotate, 0, ForceMode.Force);
    }


    private void Jump()
    {
        float height = _isJump ? _direction.y = heightJump : _direction.y = 0;
        //transform.Translate(_direction * height * Time.fixedDeltaTime);
        _rb.AddForce(new Vector3 (0, height, 0), ForceMode.Impulse);
    }

    private void Move()
    {
        float s = (_isForce) ? speed * 2f : speed;

        //transform.Translate(_direction.normalized * s * Time.fixedDeltaTime);
        _rb.AddForce(_direction.normalized * s, ForceMode.Force);
    }

    private void Fire()
    {
        GameObject bullet = GameObject.Instantiate(_bulletPrefab, _spawnBullet.position, _spawnBullet.rotation);

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
        _hp -= damage;
        if (_hp <= 0)
            Destroy(gameObject);
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


    internal bool IsItem(string item)
    {
        return _inventory.ContainsKey(item);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlueKey"))
        {
            if (_inventory.ContainsKey("BlueKey"))
                _inventory["Bluekey"] += 1;
            else
            {
                _inventory.Add("BlueKey", 1);
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("RedKey"))
        {
            if (_inventory.ContainsKey("RedKey"))
                _inventory["RedKey"] += 1;
            else
            {
                _inventory.Add("RedKey", 2);
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("BrownKey"))
        {
            if (_inventory.ContainsKey("BrownKey"))
                _inventory["BrownKey"] += 1;
            else
            {
                _inventory.Add("BrownKey", 3);
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
            _isGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
            _isGround = false;
    }

}
