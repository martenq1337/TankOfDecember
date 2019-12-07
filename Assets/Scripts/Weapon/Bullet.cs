using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public IWeapon Weapon { get; set; }
    private bool _IsPrinted = false;

    private void Update()
    {
        if (!_IsPrinted)
        {
            Weapon.Action();
            _IsPrinted = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
