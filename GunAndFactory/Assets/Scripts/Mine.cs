using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private float _damage = 50f;

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<ITakeDamage>();
        if (obj != null)
            obj.Boom(_damage);
        Destroy(gameObject);
    }
}
