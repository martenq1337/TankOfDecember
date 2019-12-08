using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public IWeapon Weapon { get; set; }
    public Vector3 InitPosition { get; set; }

    private void Awake()
    {
        InitPosition = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Weapon.Action(InitPosition, this.transform.position, other.transform.parent.gameObject);
    }
}
