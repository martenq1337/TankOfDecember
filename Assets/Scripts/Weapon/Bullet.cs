using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public IWeapon Weapon { get; set; }
    public Vector3 InitPosition { get; set; }

    public GameObject StartShootVFX;
    public GameObject HitVFX;

    private void Awake()
    {
        InitPosition = this.transform.position;
        StartShootVFX = GameObject.Instantiate(StartShootVFX, transform.position,Quaternion.identity);
        StartShootVFX.transform.Rotate(new Vector3(0, gameObject.transform.rotation.eulerAngles.y, 0));
        Destroy(StartShootVFX,3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StringContainer.TankTag)
        {
            Weapon.Action(InitPosition, this.transform.position, other.transform.parent.gameObject);
            Destroy(gameObject);

            HitVFX = Instantiate(HitVFX,this.transform.position,Quaternion.identity);
            ParticleSystem hitParticleSystem = HitVFX.GetComponent<ParticleSystem>();
            Destroy(HitVFX, hitParticleSystem.main.duration);
        }
    }
}
