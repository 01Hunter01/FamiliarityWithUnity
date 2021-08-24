using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private Transform _target;
    private float _damage;
    private float _speed = 20f;

    public void Init(float damage, float lifeTime = 0f, string tag = "")
    {
        _damage = damage;
        Destroy(gameObject, lifeTime);
    }

    private void Start()
    {
       // _target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.Translate(transform.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<ITakeDamage>();
        if (obj != null)
            obj.Hit(_damage);
        Destroy(gameObject);
    }

}
