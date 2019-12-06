using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject UpperPart;
    public GameObject InitBulletPosition;

    private List<IWeapon> Weapons { get; set; }

    private void Start()
    {
        Weapons = new List<IWeapon>();
        Weapons.Add(new Shark());
    }

    private void Update()
    {
        Debug.Log(InitBulletPosition.transform.position);
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        Quaternion rotation = UpperPart.transform.rotation;
        GameObject bullet = Instantiate(Bullet, InitBulletPosition.transform.position,rotation);

        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,-1000,0));
    }
}
