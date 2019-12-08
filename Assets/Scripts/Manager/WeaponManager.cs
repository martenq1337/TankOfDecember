using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject Bullet { get; set; }
    public GameObject UpperPart { get; set; }
    public GameObject InitBulletPosition { get; set; }

    private List<IWeapon> _Weapons;
    private IWeapon _SelectedWeapon;
    private int _SelectedWeaponId = 0;
    private float _BulletSpeed = 500;

    private void Start()
    {
        Push pushWeapon = gameObject.AddComponent<Push>();
        Pull pullWeapon = gameObject.AddComponent<Pull>();
        //RandomMove randomMoveWeapon = gameObject.AddComponent<RandomMove>();

        _Weapons = new List<IWeapon>()
        {
            pushWeapon, pullWeapon//, randomMoveWeapon
        };
        _SelectedWeapon = _Weapons[_SelectedWeaponId];
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
        bullet.GetComponent<Bullet>().Weapon = _SelectedWeapon;
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, -_BulletSpeed, 0));

        Destroy(bullet, 5);
    }
}
