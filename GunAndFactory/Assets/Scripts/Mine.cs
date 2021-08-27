using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private float _damage = 50f;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
           
    }


    private void OnCollisionEnter(Collision other)
    {
        var obj = other.gameObject.GetComponent<ITakeDamage>();

        if (obj != null)
        {
            obj.Boom(_damage);
            _rb.AddExplosionForce(100f, transform.position, 15f, 10f, ForceMode.Impulse);
            Destroy(gameObject);
        }
        

        //if (Physics.SphereCast(transform.position, 5f, transform.forward, out RaycastHit hit, 10f))
        //{
        //    if (hit.collider.tag == "Player" && hit.distance > 0 && hit.distance <= 3f && obj != null)
        //    {
        //        obj.Boom(_damage);
        //        hit.rigidbody.AddForce(new Vector3(5f, 2f, 0), ForceMode.Impulse);
        //        Destroy(gameObject);
        //    }
        //    else if (hit.collider.tag == "Player" && hit.distance > 3f && hit.distance <= 5f && obj != null)
        //    {
        //        obj.Boom(_damage / 2);
        //        hit.rigidbody.AddForce(new Vector3(3f, 2f, 0), ForceMode.Impulse);
        //        Destroy(gameObject);
        //    }
        //}
    }
}
