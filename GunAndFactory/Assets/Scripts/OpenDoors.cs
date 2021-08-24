using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenDoors : MonoBehaviour
{
    public UnityEvent enter;
    public UnityEvent exit;

    [SerializeField] private string _needItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (string.IsNullOrEmpty(_needItem) || other.GetComponent<Player>().IsItem(_needItem))
            enter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            if (string.IsNullOrEmpty(_needItem) || other.GetComponent<Player>().IsItem(_needItem))
                exit.Invoke();
    }
}
