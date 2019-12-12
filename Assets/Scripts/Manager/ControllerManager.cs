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

    private void Awake()
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
        }

        PositionManager positionManager = gameObject.AddComponent<PositionManager>();
        positionManager.SetParameters(this.gameObject);

    }
}
