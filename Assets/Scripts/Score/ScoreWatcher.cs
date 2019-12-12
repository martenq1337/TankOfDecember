using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWatcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StringContainer.PlayerTag)
        {
            ScoreManager.PlayerBoxScore+=6;
        }
        else if (other.tag == StringContainer.EnemyTag)
        {
            ScoreManager.EnemyBoxScore+=6;
        }
    }
}
