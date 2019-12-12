using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponManagerBase : MonoBehaviour
{
    public GameObject BulletVFX { get; set; }
    public GameObject HitVFX { get; set; }
    public GameObject MuzzleVFX { get; set; }
    public GameObject UpperPart { get; set; }
    public GameObject InitBulletPosition { get; set; }

    private IWeapon _Weapon;
    private float _BulletSpeed = 500;
    private float _TimeToShoot = 0f;

    protected bool _CanShoot = true;
    protected float _Timer = 0;

    private void Start()
    {
        _Weapon = gameObject.AddComponent<Weapon>();
        _TimeToShoot = _Weapon.Timer;
    }

    

    protected void CountDown()
    {
        _Timer += Time.deltaTime;
        if (_Timer >= _TimeToShoot)
        {
            _CanShoot = true;
        }
    }

    protected void Shoot()
    {
        Quaternion rotation = UpperPart.transform.rotation;
        GameObject bullet = Instantiate(BulletVFX, InitBulletPosition.transform.position,rotation);
        bullet.GetComponent<Bullet>().Weapon = _Weapon;
        bullet.GetComponent<Bullet>().HitVFX = this.HitVFX;
        bullet.GetComponent<Bullet>().MuzzleVFX = this.MuzzleVFX;
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, -_BulletSpeed, 0));
        bullet.GetComponent<Bullet>().Shoot();

        Destroy(bullet, 5);
    }

}
