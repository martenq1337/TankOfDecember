using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Pull : WeaponBase
{
    public override void Action(Vector3 bulletStartPosition, Vector3 bulletEndPosition, GameObject tank)
    {
        Vector3 bulletDirection = bulletStartPosition - bulletEndPosition;
        bulletDirection = bulletDirection.normalized;
        bulletDirection *= Force;

        Rigidbody tankRigidbody = tank.GetComponent<Rigidbody>();
        tankRigidbody.AddForceAtPosition(bulletDirection, bulletEndPosition, ForceMode.Impulse);
    }
}
