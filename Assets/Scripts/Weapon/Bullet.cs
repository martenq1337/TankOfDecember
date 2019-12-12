using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public IWeapon Weapon { get; set; }
    public Vector3 InitPosition { get; set; }

    public GameObject MuzzleVFX;
    public GameObject HitVFX;


    public void Shoot()
    {
        MuzzleVFX = GameObject.Instantiate(MuzzleVFX, transform.position, Quaternion.identity);
        MuzzleVFX.transform.Rotate(new Vector3(0, gameObject.transform.rotation.eulerAngles.y, 0));
        Destroy(MuzzleVFX, 3);
    }

    private void Awake()
    {
        InitPosition = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StringContainer.TankTag)
        {
            HitVFX = Instantiate(HitVFX, this.transform.position, Quaternion.identity);
            ParticleSystem hitParticleSystem = HitVFX.GetComponent<ParticleSystem>();
            Destroy(HitVFX, 1.5f);
            Destroy(gameObject);

            string tag = other.transform.parent.gameObject.tag;

            if (tag == StringContainer.PlayerTag)
                ScoreManager.EnemyShootScore++;
            if (tag == StringContainer.EnemyTag)
                ScoreManager.PlayerShootScore++;
        }
    }
}
