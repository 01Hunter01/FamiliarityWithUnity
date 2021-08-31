using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private float _damage = 50f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
           
    }


    private void OnCollisionEnter(Collision other)
    {
        var obj = other.gameObject.GetComponent<ITakeDamage>();

        Collider[] sphere = Physics.OverlapSphere(transform.position, 5f);

        for(int i = 0; i < sphere.Length; i++)
        {
            if (sphere[i].CompareTag("Player"))
            {
                obj.Boom(_damage);
                sphere[i].GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-5f, 5f), 3f, -3f), ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
        
    }
}
