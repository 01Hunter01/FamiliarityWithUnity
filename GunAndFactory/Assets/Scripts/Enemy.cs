using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spawnBullet;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform[] _wayPoints;
    private Transform _target;

    [SerializeField] private float _hp = 100;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _speedRotate = 4f;
    

    private bool _isFire;
    int m_CurrentWaypointIndex;

    private void Awake()
    {
        _isFire = false;
    }

    private void Start()
    {
        _target = FindObjectOfType<Player>().transform;

        _agent.SetDestination(_wayPoints[0].position);

        
    }

    private void Update()
    {
        if (Vector3.Distance(_target.position, transform.position) <= 15f)
        {
            Vector3 dir = (_target.position - transform.position);
            Vector3 stepDir = Vector3.RotateTowards(transform.forward, dir, _speedRotate * Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(stepDir);

            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(Patrol());
        }
        
        
        if(Physics.Raycast(_spawnBullet.position, _spawnBullet.forward, out RaycastHit hit))
        {
            if (hit.distance <= 15f)
            {
                _isFire = true;
                Fire();
            }
            else
            {
                _isFire = false;
            }
        }

        
            

        
    }

    public void Boom(float damage)
    {
        _hp -= damage / 2;
        if (_hp <= 0)
            Destroy(gameObject);
    }

    public void Hit(float damage)
    {
        _hp -= damage / 1.5f;
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

    private void Fire()
    {
        GameObject bullet = GameObject.Instantiate(_bulletPrefab, _spawnBullet.position, _spawnBullet.rotation);

        bullet.GetComponent<Bullet>().Init(5f, 15f);

        _isFire = false;
    }

    private IEnumerator Patrol()
    {
        yield return new WaitForSeconds(3f);

        if (_agent.remainingDistance < _agent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % _wayPoints.Length;
            _agent.SetDestination(_wayPoints[m_CurrentWaypointIndex].position);
        }

        yield return new WaitForSeconds(1f);

    }
}
