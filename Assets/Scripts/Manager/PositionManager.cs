using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    private Vector3 _SavedTankPosition { get; set; }
    private Vector3 _SavedUpperPartPosition { get; set; }
    private Vector3 _SavedLowerPartPosition { get; set; }
    private Quaternion _SavedTankRotation { get; set; }
    private Quaternion _SavedUpperPartRotation { get; set; }
    private Quaternion _SavedLowerPartRotation { get; set; }

    private GameObject _Tank;
    private GameObject _LowerPart;
    private GameObject _UpperPart;

    //save start position, rotation
    public void SetParameters(GameObject tankGameObject)
    {
        _Tank = tankGameObject;
        _UpperPart = tankGameObject.transform.Find(StringContainer.UpperPart).gameObject;
        _LowerPart = tankGameObject.transform.Find(StringContainer.LowerPart).gameObject;

        _SavedTankPosition = _Tank.transform.position;
        _SavedUpperPartPosition = tankGameObject.transform.Find(StringContainer.UpperPart).gameObject.transform.position;
        _SavedLowerPartPosition = tankGameObject.transform.Find(StringContainer.LowerPart).gameObject.transform.position;

        _SavedTankRotation = _Tank.transform.rotation;
        _SavedUpperPartRotation = tankGameObject.transform.Find(StringContainer.UpperPart).gameObject.transform.rotation;
        _SavedLowerPartRotation = tankGameObject.transform.Find(StringContainer.LowerPart).gameObject.transform.rotation;

    }

    //reset if the tank falls down
    public void ResetPosition()
    {
        _Tank.transform.position = _SavedTankPosition;
        _Tank.transform.rotation = _SavedTankRotation;
        _UpperPart.transform.position = _SavedUpperPartPosition;
        _UpperPart.transform.rotation = _SavedUpperPartRotation;
        _LowerPart.transform.position = _SavedLowerPartPosition;
        _LowerPart.transform.rotation = _SavedLowerPartRotation;
        _Tank.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _Tank.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }
}
