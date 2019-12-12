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
}
