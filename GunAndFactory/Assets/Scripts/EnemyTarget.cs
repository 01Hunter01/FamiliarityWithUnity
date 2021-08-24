using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float _speed = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_target.position, transform.position) > 15f)
            return;

        Vector3 dir = (_target.position - transform.position);

        Vector3 stepDir = Vector3.RotateTowards(transform.forward, dir, _speed * Time.deltaTime, 0f);

        transform.rotation = Quaternion.LookRotation(stepDir);
        

    }
}