using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerTrapWall : MonoBehaviour
{
    [SerializeField] private Animator _wall;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
           _wall.SetTrigger("Move");

        gameObject.GetComponent<Collider>().enabled = false;
        
    }
}
