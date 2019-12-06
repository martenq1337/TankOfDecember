﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject Bullet { get; set; }
    public GameObject UpperPart { get; set; }
    public GameObject InitBulletPosition { get; set; }

    private List<IWeapon> Weapons;
    private int _SelectedWeapon = 0;

    private void Start()
    {
        Weapons = new List<IWeapon>();
        Weapons.Add(new Shark());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        Quaternion rotation = UpperPart.transform.rotation;
        GameObject bullet = Instantiate(Bullet, InitBulletPosition.transform.position,rotation);

        float force = Weapons[_SelectedWeapon].Force;
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, -force, 0));
        //bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);

        Destroy(bullet, 5);
    }
}
