using UnityEngine;

public interface IWeapon 
{
    void Action(Vector3 bulletStart, Vector3 bulletEnd, GameObject tank);
    int Force { get; set; }
    float Timer { get; set; }
}
