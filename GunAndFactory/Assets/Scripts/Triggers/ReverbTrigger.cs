using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverbTrigger : MonoBehaviour
{

    private AudioReverbZone _reverbZone;

    void Awake()
    {
        _reverbZone = GetComponent<AudioReverbZone>();
        _reverbZone.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        _reverbZone.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _reverbZone.enabled = false;
    }
}
