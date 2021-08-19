using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float _hp = 100;

    public void Boom(float damage)
    {
        _hp -= damage / 2;
        if (_hp <= 0)
            Destroy(gameObject);
    }

    public void Hit(float damage)
    {
        _hp -= damage / 2;
        if (_hp <= 0)
            Destroy(gameObject);

    }

    public void HitTrapFloor(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void HitTrapWall(float damage)
    {
        throw new System.NotImplementedException();
    }
}
