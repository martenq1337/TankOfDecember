using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody _RigidBody;
    private float _Speed = 3.0f;

    private void Start()
    {
        _RigidBody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back* Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left* Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime);
    }
}
