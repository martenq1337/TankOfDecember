﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffWatcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StringContainer.EnemyTag || other.tag == StringContainer.PlayerTag)
            other.GetComponent<PositionManager>().ResetPosition();
    }

}