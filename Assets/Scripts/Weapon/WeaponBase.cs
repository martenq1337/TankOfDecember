using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    public int Force { get; set; }
    public float Timer { get; set; }
    public abstract void Action(Vector3 bulletDirection, Vector3 bulletEndPosition, GameObject tank);

    public WeaponBase()
    {
        Timer = 0.3f;
        Force = 2;
    }
}
