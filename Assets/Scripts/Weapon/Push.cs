using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : WeaponBase
{
    public override void Action(Vector3 bulletStartPosition, Vector3 bulletEndPosition, GameObject tank)
    {
        Vector3 bulletDirection = bulletEndPosition - bulletStartPosition;
        bulletDirection = bulletDirection.normalized;
        bulletDirection *= Force;

        Rigidbody tankRigidbody = tank.GetComponent<Rigidbody>();
        tankRigidbody.AddForceAtPosition(bulletDirection, bulletEndPosition, ForceMode.Impulse);
    }
}
