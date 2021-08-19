using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerTrapWall : MonoBehaviour
{
    public UnityEvent _TrapWall;
    //[SerializeField] private GameObject _target;
    //[SerializeField] private GameObject _trapwall;
    //private float _speed = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _TrapWall.Invoke();
        //transform.position = Vector3.MoveTowards(_trapwall.transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
