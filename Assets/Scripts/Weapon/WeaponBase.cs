using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public int Force { get; set; }
    public abstract void Action(Vector3 bulletDirection, Vector3 bulletEndPosition, GameObject tank);

    public WeaponBase()
    {
        Force = 2;
    }
}
