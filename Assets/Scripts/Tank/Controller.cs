using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject _UpperPart;

    private Rigidbody _RigidBody;
    private float _Rotation = 30.0f;
    private RaycastHit hit;
    private int mapLayerMask = 1 << 8;

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
            transform.Rotate(new Vector3(0f, -_Rotation * Time.deltaTime, 0f));
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3( 0f, _Rotation * Time.deltaTime, 0f));

        //measure the distance from the camera to the map
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Vector3 startPosition = _UpperPart.transform.position;
                Vector3 endPosition = hit.point;
                startPosition.y = 0;
                endPosition.y = 0;

                float angle = AngleBetweenTwoPoints(endPosition, startPosition);
                angle = (360 - angle) + 90;

                _UpperPart.transform.rotation = Quaternion.Euler(new Vector3(-90, angle, 0f));
            }
        }
    }

   

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.z - b.z, a.x - b.x) * Mathf.Rad2Deg;
    }

}
