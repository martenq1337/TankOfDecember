using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshWatcher : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == StringContainer.EnemyTag)
    //    {
    //        Debug.Log("canmove");
    //        EnemyController.CanMove = true;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == StringContainer.EnemyTag)
    //    {
    //        Debug.Log("cant move");
    //        EnemyController.CanMove = false;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
