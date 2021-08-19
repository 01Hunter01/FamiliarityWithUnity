using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float angle;

    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (_target.position - transform.position);

        

        Vector3 stepDir = Vector3.RotateTowards(transform.forward, dir, _speed * Time.deltaTime, 0f);

        angle = Vector3.Angle(transform.forward, dir);

        transform.rotation = Quaternion.LookRotation(stepDir);
        

    }
}