using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float _hp = 100;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform[] _wayPoints;

    int m_CurrentWaypointIndex;


    private void Start()
    {
        _agent.SetDestination(_wayPoints[0].position);
    }

    private void Update()
    {
        if(_agent.remainingDistance < _agent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % _wayPoints.Length;
            _agent.SetDestination(_wayPoints[m_CurrentWaypointIndex].position);
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
        _hp -= damage / 2;
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
}
