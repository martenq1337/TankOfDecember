using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : TankBase
{
    private NavMeshAgent _Agent;
    private Vector3 _PreviousPosition;
    private Vector3 _Destination;

    private void Awake()
    {
        _Agent = GetComponent<NavMeshAgent>();
        //_Destination = ScoreManager._EnemySpawnedObject.transform.position;
        //_PreviousPosition = _Destination;
        //_Agent.SetDestination(_Destination);
    }

    private void Update()
    {
        _Destination = ScoreManager._EnemySpawnedObject.transform.position;

        if (_PreviousPosition != _Destination)
        {
            _Agent.SetDestination(_Destination);
            _PreviousPosition = _Destination;
        } 
    }
}
