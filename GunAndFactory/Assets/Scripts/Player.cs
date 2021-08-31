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
    [SerializeField] Animator _anim;

    private Rigidbody _rb;

    private Dictionary<string, int> _inventory;

    

    public float speed;
    public float speedRotate;
    public float heightJump;

    private bool _isJump;
    private bool _isForce;
    
    private bool _isGround;
    private Vector3 _direction;
    private Vector3 rotationPlayer;

    private void Awake()
    {
        
        _inventory = new Dictionary<string, int>();
        _anim = GetComponent<Animator>();
       
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        

        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _isForce = Input.GetButton("Force");
        _isJump = Input.GetButton("Jump") && _isGround;


        if (_direction == Vector3.zero)
        {
            _anim.SetBool("IsMove", false);

            if (Input.GetMouseButtonDown(0))
                _anim.SetTrigger("Shoot");
        }
            
        else
            _anim.SetBool("IsMove", true);

        
    }

    private void FixedUpdate()
    {
        //if (_isFire)
        //    Fire();

        Move();
        Jump();



        float yRot = Input.GetAxisRaw("Mouse X");
        rotationPlayer = new Vector3(0f, yRot * speedRotate, 0f);
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(rotationPlayer));

        //transform.Rotate(0, Input.GetAxis("Mouse X") * speedRotate * Time.fixedDeltaTime, 0);
        

        
    }


    private void Jump()
    {
        float height = _isJump ? _direction.y = heightJump : _direction.y = 0;
        //transform.Translate(_direction * height * Time.fixedDeltaTime);
        _rb.AddForce(Vector3.up * height, ForceMode.Impulse);
    }

    private void Move()
    {
        float s = (_isForce) ? speed * 2f : speed;

        //transform.Translate(_direction.normalized * s * Time.fixedDeltaTime);
        //_rb.AddForce(_direction.normalized * s, ForceMode.Force);
        Vector3 m_Input = new Vector3(_direction.x, 0f, _direction.z);
        _rb.MovePosition(transform.position + m_Input * Time.fixedDeltaTime * s);
    }

    private void Fire()
    {
        GameObject bullet = GameObject.Instantiate(_bulletPrefab, _spawnBullet.position, _spawnBullet.rotation);

        bullet.GetComponent<Bullet>().Init(10f, 4f);
    }

    public void Boom(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            _anim.SetTrigger("Die");
        }
    }

    public void Hit(float damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            _anim.SetTrigger("Die");
        }
    }

    public void HitTrapFloor(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            _anim.SetTrigger("Die");
        }
    }

    public void HitTrapWall(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            _anim.SetTrigger("Die");
        }
            
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
