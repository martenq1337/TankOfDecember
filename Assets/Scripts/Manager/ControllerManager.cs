using System.Collections;
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

    public AudioClip Shoot;

    public static float Timer = 0f;
    public static bool Activated = false;
    public static readonly float SleepTime = 5.0f;

    private bool _IsLocalActivated = false;


    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= SleepTime && !_IsLocalActivated)
        {
            _IsLocalActivated = true;
            Activated = true;
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
            playerWeaponManager.ShootSound = Shoot;
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
            enemyWeaponManager.ShootSound = Shoot;
        }

        PositionManager positionManager = gameObject.AddComponent<PositionManager>();
        positionManager.SetParameters(this.gameObject);

    }
}
