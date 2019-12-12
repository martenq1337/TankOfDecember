using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject UpperPart;

    private NavMeshAgent _Agent;
    private Vector3 _Destination;
    private bool _IsDestinationSet = false;
    private int _PreviousScore = 0;
    private GameObject _Player;

    private Vector3 _Direction;

    public void FixTank()
    {
        _Agent.enabled = false;
        _Agent.enabled = true;
    }

    private void Awake()
    {
        _Agent = GetComponent<NavMeshAgent>();
        _Player = GameObject.FindWithTag(StringContainer.PlayerTag);
    }

    private void Update()
    {
        Vector3 startPosition = UpperPart.transform.position;
        Vector3 endPosition = _Player.gameObject.transform.position;
        startPosition.y = 0;
        endPosition.y = 0;

        float angle = AngleBetweenTwoPoints(endPosition, startPosition);
        angle = (360 - angle) + 90;

        UpperPart.transform.rotation = Quaternion.Euler(new Vector3(-90, angle, 0f));

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

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg;
    }
}
