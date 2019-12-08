using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWatcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StringContainer.PlayerTag)
        {
            ScoreManager.PlayerScore++;
        }
        else if (other.tag == StringContainer.EnemyTag)
        {
            ScoreManager.EnemyScore++;
        }
    }
}
