using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : IWeapon
{
    public float Damage { get; set; }
    public float Force { get; set; }
    public float Timer { get; set; }

    public Shark()
    {
        Force = 1500;
    }
}
