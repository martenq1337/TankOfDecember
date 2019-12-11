using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject BulletVFX { get; set; }
    public GameObject HitVFX { get; set; }
    public GameObject MuzzleVFX { get; set; }
    public GameObject UpperPart { get; set; }
    public GameObject InitBulletPosition { get; set; }

    private WeaponIconManager _WeaponIconManager;
    private List<IWeapon> _Weapons;
    private IWeapon _SelectedWeapon;
    private int _SelectedWeaponId = 0;
    private float _BulletSpeed = 500;
    private float _Timer = 0;
    private float _TimeToShoot = 0;
    private bool _CanShoot = true;

    private void Start()
    {
        Push pushWeapon = gameObject.AddComponent<Push>();
        Pull pullWeapon = gameObject.AddComponent<Pull>();

        _Weapons = new List<IWeapon>()
        {
            pushWeapon, pullWeapon
        };
        _SelectedWeapon = _Weapons[_SelectedWeaponId];

        _WeaponIconManager = gameObject.GetComponent<WeaponIconManager>();
        _WeaponIconManager.SelectedWeaponID = _SelectedWeaponId;
        _TimeToShoot = _Weapons[_SelectedWeaponId].Timer;
    }

    private void Update()
    {
        if (_CanShoot && Input.GetMouseButton(0))
        {
            Shoot();
            _CanShoot = false;
            _Timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _SelectedWeaponId = 0;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                _SelectedWeaponId = 1;

            _SelectedWeapon = _Weapons[_SelectedWeaponId];
            _WeaponIconManager.ChangeIcon(_SelectedWeaponId);
        }

        CountDown();

    }

    private void CountDown()
    {
        _Timer += Time.deltaTime;
        if (_Timer >= _TimeToShoot)
        {
            _CanShoot = true;
        }
    }

    private void Shoot()
    {
        Quaternion rotation = UpperPart.transform.rotation;
        GameObject bullet = Instantiate(BulletVFX, InitBulletPosition.transform.position,rotation);
        bullet.GetComponent<Bullet>().Weapon = _SelectedWeapon;
        bullet.GetComponent<Bullet>().HitVFX = this.HitVFX;
        bullet.GetComponent<Bullet>().MuzzleVFX = this.MuzzleVFX;
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, -_BulletSpeed, 0));
        bullet.GetComponent<Bullet>().Shoot();

        Destroy(bullet, 5);
    }
}
