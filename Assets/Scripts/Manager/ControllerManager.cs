﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{
    public GameObject UpperPart;
    public GameObject Bullet;
    public GameObject HitVFX;
    public GameObject MuzzleVFX;
    public GameObject InitBulletPosition;
    public bool IsPlayer = false;

    private bool _Activated = false;
    private float _Timer = 0f;
    
    private void Update()
    {
        _Timer += Time.deltaTime;
        if (_Timer>=3.0 && !_Activated)
        {
            _Activated = true;
            Init();
        }
    }
    //private void Awake()
    private void Init()
    {
        if (IsPlayer)
        {
            PlayerController controller = gameObject.AddComponent<PlayerController>();
            controller.UpperPart = this.UpperPart;

            PlayerWeaponManager playerWeaponManager = gameObject.AddComponent<PlayerWeaponManager>();
            playerWeaponManager.UpperPart = this.UpperPart;
            playerWeaponManager.BulletVFX = this.Bullet;
            playerWeaponManager.HitVFX = this.HitVFX;
            playerWeaponManager.MuzzleVFX = this.MuzzleVFX;
            playerWeaponManager.InitBulletPosition = this.InitBulletPosition;
        }
        else
        {
            EnemyController controller = gameObject.AddComponent<EnemyController>();
            controller.UpperPart = this.UpperPart;

            EnemyWeaponManager enemyWeaponManager = gameObject.AddComponent<EnemyWeaponManager>();
            enemyWeaponManager.UpperPart = this.UpperPart;
            enemyWeaponManager.BulletVFX = this.Bullet;
            enemyWeaponManager.HitVFX = this.HitVFX;
            enemyWeaponManager.MuzzleVFX = this.MuzzleVFX;
            enemyWeaponManager.InitBulletPosition = this.InitBulletPosition;
        }

        PositionManager positionManager = gameObject.AddComponent<PositionManager>();
        positionManager.SetParameters(this.gameObject);

    }
}
