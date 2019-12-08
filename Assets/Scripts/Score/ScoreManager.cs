using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject ItemToPickup;
    public GameObject ScorePositionParent;

    public static int PlayerScore = 0;
    public static int EnemyScore = 0;

    private List<Vector3> _Positions;
    private int _RandomIndex;
    private GameObject _SpawnedObject;

    private int _PlayerPreviousScore = 0;
    private int _EnemyPreviousScore = 0;

    void Start()
    {
        _Positions = new List<Vector3>();

        foreach (Transform child in ScorePositionParent.transform)
            _Positions.Add(child.transform.position);

        _RandomIndex = Random.Range(0, _Positions.Count - 1);
        SpawnObject();

    }

    private void Update()
    {
        if (_PlayerPreviousScore != PlayerScore)
        {
            _PlayerPreviousScore = PlayerScore;
            SpawnObject();
        }
        Debug.Log(PlayerScore);
    }

    private void SpawnObject()
    {
        if (_SpawnedObject != null)
            Destroy(_SpawnedObject);

        int nextRandomIndex = -1;
        do
        {
            nextRandomIndex = _RandomIndex = Random.Range(0, _Positions.Count - 1);
        } while (nextRandomIndex != _RandomIndex);
        _RandomIndex = nextRandomIndex;

        _SpawnedObject = Instantiate(ItemToPickup, _Positions[_RandomIndex], Quaternion.identity);
        _SpawnedObject.AddComponent<ScoreWatcher>();
    }

   
}
