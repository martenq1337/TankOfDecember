using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public GameObject UpperPart;
    public GameObject Bullet;
    public GameObject InitBulletPosition;
    public bool IsPlayer = false;

    private void Awake()
    {
        if (IsPlayer)
        {
            PlayerController controller = gameObject.AddComponent<PlayerController>();
            controller.UpperPart = this.UpperPart;

            WeaponManager weapon = gameObject.AddComponent<WeaponManager>();
            weapon.UpperPart = this.UpperPart;
            weapon.Bullet = this.Bullet;
            weapon.InitBulletPosition = this.InitBulletPosition;
        }
        else
        {
            gameObject.AddComponent<EnemyController>();
        }
    }
}
