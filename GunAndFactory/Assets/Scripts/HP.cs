using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    
    private float _hp = 50;

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<IHealthAmmo>();

        if (obj != null)
        {
            obj.Health(_hp);
            Destroy(gameObject);
        }
    }
}
