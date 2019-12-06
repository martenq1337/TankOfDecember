using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject UpperPart;

    private List<IWeapon> Weapons { get; set; }

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
        Instantiate(Bullet);
    }
}
