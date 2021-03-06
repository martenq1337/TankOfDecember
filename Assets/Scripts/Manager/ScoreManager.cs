﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public AudioClip PickUpCoin;
    private AudioSource _AudioSource;

    public GameObject PlayerItemToPickup;
    public GameObject PlayerScorePositionParent;
    public GameObject EnemyItemToPickup;
    public GameObject EnemyScorePositionParent;

    public Text PlayerScoreText;
    public Text EnemyScoreText;

    public static int PlayerBoxScore = 0;
    public static int EnemyBoxScore = 0;

    public static int PlayerShootScore = 0;
    public static int EnemyShootScore = 0;

    private List<Vector3> _PlayerScorePositions;
    private List<Vector3> _EnemyScorePositions;
    private int _PlayerRandomIndex;
    private int _EnemyRandomIndex;

    private GameObject _PlayerSpawnedObject;
    public static GameObject _EnemySpawnedObject;

    private int _PlayerPreviousScore = 0;
    private int _EnemyPreviousScore = 0;

    private bool _IsTextActivated = false;

    void Awake()
    {
        _AudioSource = gameObject.AddComponent<AudioSource>();
        _AudioSource.clip = PickUpCoin;
        _AudioSource.volume = .3f;

        PlayerScoreText.enabled = false;
        EnemyScoreText.enabled = false;

        _PlayerScorePositions = new List<Vector3>();
        _EnemyScorePositions = new List<Vector3>();

        foreach (Transform child in PlayerScorePositionParent.transform)
            _PlayerScorePositions.Add(child.transform.position);

        foreach (Transform child in EnemyScorePositionParent.transform)
            _EnemyScorePositions.Add(child.transform.position);

        _PlayerRandomIndex = Random.Range(0, _PlayerScorePositions.Count - 1);
        _EnemyRandomIndex = Random.Range(0, _EnemyScorePositions.Count - 1);

        SpawnObject(PlayerItemToPickup, ref _PlayerSpawnedObject, _PlayerRandomIndex, _PlayerScorePositions);
        SpawnObject(EnemyItemToPickup, ref _EnemySpawnedObject, _EnemyRandomIndex, _EnemyScorePositions);
    }

    private void Update()
    {
        if (ControllerManager.Activated && !_IsTextActivated)
        {
            _IsTextActivated = true;
            PlayerScoreText.enabled = true;
            EnemyScoreText.enabled = true;
        }

        if (_PlayerPreviousScore != PlayerBoxScore)
        {
            _PlayerPreviousScore = PlayerBoxScore;
            SpawnObject(PlayerItemToPickup, ref _PlayerSpawnedObject, _PlayerRandomIndex, _PlayerScorePositions);
            _AudioSource.Play();
        }

        if (_EnemyPreviousScore != EnemyBoxScore)
        {
            _EnemyPreviousScore = EnemyBoxScore;
            SpawnObject(EnemyItemToPickup, ref _EnemySpawnedObject, _EnemyRandomIndex, _EnemyScorePositions);
            _AudioSource.Play();
        }

    }

    private void SpawnObject(GameObject objectToSpawn,ref GameObject spawnedObject, int randomIndex, List<Vector3> positions)
    {
        if (spawnedObject != null)
            Destroy(spawnedObject);

        int nextRandomIndex = -1;
        do
        {
            nextRandomIndex = randomIndex = Random.Range(0, _PlayerScorePositions.Count - 1);
        } while (nextRandomIndex != randomIndex);
        randomIndex = nextRandomIndex;

        spawnedObject = Instantiate(objectToSpawn, positions[randomIndex], Quaternion.identity);
        spawnedObject.AddComponent<ScoreWatcher>();
    }

    private void OnGUI()
    {
        PlayerScoreText.text = (PlayerBoxScore + PlayerShootScore).ToString();
        EnemyScoreText.text = (EnemyBoxScore + EnemyShootScore).ToString();
    }


}
