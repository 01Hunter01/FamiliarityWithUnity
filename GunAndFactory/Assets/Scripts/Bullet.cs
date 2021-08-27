using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private Transform _target;
    private Rigidbody _rb;
    private float _damage;
    [SerializeField] private float _force = 10f;

    public void Init(float damage, float lifeTime = 0f, string tag = "")
    {
        _damage = damage;
        Destroy(gameObject, lifeTime);
    }

    private void Start()
    {
        // _target = GameObject.FindGameObjectWithTag("Enemy").transform;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        //transform.Translate(transform.forward * _speed * Time.deltaTime);
        _rb.AddForce(transform.forward * _force, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<ITakeDamage>();
        if (obj != null)
            obj.Hit(_damage);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        var obj = other.gameObject.GetComponent<ITakeDamage>();
        if (obj != null)
            obj.Hit(_damage);
        Destroy(gameObject);
    }

}
