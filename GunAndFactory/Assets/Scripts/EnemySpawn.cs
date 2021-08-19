using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] GameObject[] _Enemies;
    [SerializeField] Transform[] _spawnEnemyPlace;


    //float spawnTime = 4f;
    //int maxEnemies = 5;
    //int enemyCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0, j = 0; i < _spawnEnemyPlace.Length && j < _Enemies.Length; i++, j++)
        {
            Instantiate(_Enemies[j], _spawnEnemyPlace[i].position, _spawnEnemyPlace[i].rotation);
        }
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void Spawn()
    //{
    //    if (enemyCounter < maxEnemies)
    //    {
    //        GameObject enemy = GameObject.Instantiate(_Enemy, _spawnEnemy);
    //        Destroy(enemy, 2f);
    //        enemyCounter++;
    //    }
    //}


}
