using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public int Force { get; set; }
    public float Timer { get; set; }

    public Weapon()
    {
        Timer = .5f;
        Force = 2;
    }

}
