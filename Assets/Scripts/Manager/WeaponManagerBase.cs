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

    private float _TimeToShoot = 0f;

    protected bool _CanShoot = true;
    protected IWeapon _Weapon;
    protected float _Timer = 0;
    protected float _BulletSpeed = 500;


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

    protected abstract void Shoot();
    

}
