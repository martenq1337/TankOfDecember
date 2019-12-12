using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : TankBase
{
    public static bool CanMove = true;

    private NavMeshAgent _Agent;
    private Vector3 _Destination;
    private bool _IsDestinationSet = false;
    private int _PreviousScore = 0;

    public void FixTank()
    {
        _Agent.enabled = false;
        _Agent.enabled = true;
    }

    private void Awake()
    {
        _Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Debug.Log(_Agent.isOnNavMesh);

        if (CanMove)
        {
            _Agent.enabled = true;
            if (_Agent.isOnNavMesh)
            {
                //if (!_IsDestinationSet)
                //{
                //    _Destination = ScoreManager._EnemySpawnedObject.transform.position;
                //    _Agent.SetDestination(_Destination);
                //    _IsDestinationSet = true;
                //}
                _Destination = ScoreManager._EnemySpawnedObject.transform.position;
                _Agent.SetDestination(_Destination);
                //_IsDestinationSet = true;

                _Agent.isStopped = false;
            }
        }
        else
        {
            if (_Agent.enabled && _Agent.isOnNavMesh)
                _Agent.isStopped = true;
            _Agent.enabled = false;
        }

        if (_PreviousScore != ScoreManager.EnemyScore)
        {
            _IsDestinationSet = false;
            _PreviousScore = ScoreManager.EnemyScore;
        }
    }
}
