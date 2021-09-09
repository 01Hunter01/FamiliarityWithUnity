using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFloor : MonoBehaviour
{
    private float _damage = 15f;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<ITakeDamage>();
        _anim.SetBool("isSpikeUp", true);
        if (obj != null)
            obj.HitTrapFloor(_damage);
    }

    private void OnTriggerExit(Collider other)
    {
        _anim.SetBool("isSpikeUp", false);
    }
}
