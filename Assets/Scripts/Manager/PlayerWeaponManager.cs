using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class PlayerWeaponManager : WeaponManagerBase
{
    private void Update()
    {
        if (_CanShoot && Input.GetMouseButton(0))
        {
            Shoot();
            _CanShoot = false;
            _Timer = 0;
        }

        CountDown();
    }

    protected sealed override void Shoot()
    {
        Quaternion rotation = UpperPart.transform.rotation;
        GameObject bullet = Instantiate(BulletVFX, InitBulletPosition.transform.position, rotation);
        bullet.GetComponent<Bullet>().Weapon = _Weapon;
        bullet.GetComponent<Bullet>().HitVFX = this.HitVFX;
        bullet.GetComponent<Bullet>().MuzzleVFX = this.MuzzleVFX;
        bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, -_BulletSpeed, 0));
        bullet.GetComponent<Bullet>().Shoot();

        Destroy(bullet, 5);
    }
}
