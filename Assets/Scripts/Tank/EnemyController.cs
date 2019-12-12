using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
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
        //if destination is not set, then we set it
        if (!_IsDestinationSet)
        {
            _Destination = ScoreManager._EnemySpawnedObject.transform.position;
            _Agent.SetDestination(_Destination);
            _IsDestinationSet = true;
        }

        //if the score changes, we need a new destination
        if (_PreviousScore != ScoreManager.EnemyBoxScore)
        {
            _IsDestinationSet = false;
            _PreviousScore = ScoreManager.EnemyBoxScore;
        }
    }
}
