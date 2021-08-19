using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MineSpawn : MonoBehaviour
{
    

    [SerializeField] private GameObject _mine;
    [SerializeField] private Transform[] _mineSpawnPlace;

   
    void Start()
    {
        for (int i = 0; i < _mineSpawnPlace.Length; i++)
        {
            Instantiate(_mine, _mineSpawnPlace[i].position, _mineSpawnPlace[i].rotation);
        }
    }

    


    void Update()
    {
        
    }
}
