using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : WeaponBase
{
    private float _StartTime = 0f;
    private float _IgnoreAgentTime = .5f;

    public override void Action(Vector3 bulletStartPosition, Vector3 bulletEndPosition, GameObject tank)
    {
        EnemyController.CanMove = false;

        Vector3 bulletDirection = bulletEndPosition - bulletStartPosition;
        bulletDirection = bulletDirection.normalized;
        bulletDirection *= Force;

        Rigidbody tankRigidbody = tank.GetComponent<Rigidbody>();
        tankRigidbody.AddForceAtPosition(bulletDirection, bulletEndPosition, ForceMode.Impulse);

        _StartTime = 0;
    }

    private void Update()
    {
        _StartTime += Time.deltaTime;

        if (_StartTime >= _IgnoreAgentTime)
        {
            EnemyController.CanMove = true;
        }
    }
}
