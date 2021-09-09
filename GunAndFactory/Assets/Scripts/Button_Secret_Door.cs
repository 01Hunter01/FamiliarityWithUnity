using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button_Secret_Door : MonoBehaviour
{
    public UnityEvent enter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            enter.Invoke();
       
    }
}
