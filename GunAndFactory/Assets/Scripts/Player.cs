using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, ITakeDamage, IHealthAmmo
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private Image HealthBar;
    [SerializeField] private Image _gameOver;
    [SerializeField] private float _hp;
    [SerializeField] private float _ammo = 30;
    [SerializeField] private Animator _anim;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip[] _footsteps;


    private Rigidbody _rb;

    private Dictionary<string, int> _inventory;

    [SerializeField] private float speed;
    [SerializeField] private float speedRotate;
    [SerializeField] private float heightJump;

    private bool _isJump;
    private bool _isForce;
    
    private bool _isGround;
    private Vector3 _direction;
    private Vector3 rotationPlayer;

    private void Awake()
    {
        
        _inventory = new Dictionary<string, int>();
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        

    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (_hp > 100) _hp = 100;
        
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
        Move();
        Jump();

        float yRot = Input.GetAxisRaw("Mouse X");
        rotationPlayer = new Vector3(0f, yRot * speedRotate * Time.fixedDeltaTime, 0f);
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(rotationPlayer)); 
    }


    private void Jump()
    {
        float height = _isJump ? _direction.y = heightJump : _direction.y = 0;
        _rb.AddForce(Vector3.up * height, ForceMode.Impulse);
    }

    private void Move()
    {
        float s = (_isForce) ? speed * 2f : speed;

        
        Vector3 m_Input = new Vector3(_direction.x, 0f, _direction.z);
        m_Input = transform.TransformDirection(m_Input.normalized);
        _rb.MovePosition(transform.position + m_Input * Time.fixedDeltaTime * s);
    }

    private void Fire()
    {
        _audio.Play();

        GameObject bullet = GameObject.Instantiate(_bulletPrefab, _spawnBullet.position, _spawnBullet.rotation);

        bullet.GetComponent<Bullet>().Init(10f, 4f);
    }

    private void Step()
    {
        int number = Random.Range(0, _footsteps.Length);
        _audio.PlayOneShot(_footsteps[number]);
    }

    public void Boom(float damage)
    {
        _hp -= damage;
        HealthBar.fillAmount = _hp * 0.01f;
        if (_hp <= 0)
        {
            _anim.SetTrigger("Die");
            StartCoroutine(Die());
            StartCoroutine(GameOver());
        }
    }

    public void Hit(float damage)
    {
        _hp -= damage;
        HealthBar.fillAmount = _hp * 0.01f;
        if (_hp <= 0)
        {
            _anim.SetTrigger("Die");
            StartCoroutine(Die());
            StartCoroutine(GameOver());
        }
    }

    public void HitTrapFloor(float damage)
    {
        _hp -= damage;
        HealthBar.fillAmount = _hp * 0.01f;
        if (_hp <= 0)
        {
            _anim.SetTrigger("Die");
            StartCoroutine(Die());
            StartCoroutine(GameOver());
        }
    }

    public void HitTrapWall(float damage)
    {
        _hp -= damage;
        HealthBar.fillAmount = _hp * 0.01f;
        if (_hp <= 0)
        {
            _anim.SetTrigger("Die");
            StartCoroutine(Die());
            StartCoroutine(GameOver());
        }
            
    }



    public void Health(float health)
    {
        _hp += health;
        HealthBar.fillAmount = _hp * 0.01f;
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

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);

        yield return null;
    }

    private IEnumerator GameOver()
    {
        _gameOver.gameObject.SetActive(true);

        SceneManager.LoadScene(0);

        yield return null;
    }

   

}
