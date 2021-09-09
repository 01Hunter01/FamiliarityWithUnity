using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private float _ammo = 30;

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<IHealthAmmo>();

        if (obj != null)
        {
            obj.Ammo(_ammo);
            Destroy(gameObject);
        }
    }
}
