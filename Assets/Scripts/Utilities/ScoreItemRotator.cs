using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItemRotator : MonoBehaviour
{
    public GameObject PlayerScoreItem;
    public GameObject EnemyScoreItem;

    private List<GameObject> _PlayerScores;
    private List<GameObject> _EnemyScores;

    private int _PlayerPrevScore = 0;
    private int _EnemyPrevScore = 0;

    private int _MaxScore = 5;

    private void Awake()
    {
        _PlayerScores = new List<GameObject>();
        _EnemyScores = new List<GameObject>();
    }

    void FixedUpdate()
    {
        if (_PlayerPrevScore < _MaxScore && _PlayerPrevScore != ScoreManager.PlayerScore)
        {
            Vector3 position = PlayerScoreItem.transform.position;
            position.x = position.x + (3 * _PlayerPrevScore);
            GameObject scoreItem = Instantiate(PlayerScoreItem, position, Quaternion.identity);
            _PlayerScores.Add(scoreItem);
            _PlayerPrevScore++;
        }

        if (_PlayerPrevScore < _MaxScore &&_EnemyPrevScore != ScoreManager.EnemyScore)
        {
            Vector3 position = EnemyScoreItem.transform.position;
            position.x = position.x + (3 * _PlayerPrevScore);
            GameObject scoreItem = Instantiate(EnemyScoreItem, position, Quaternion.identity);
            _EnemyScores.Add(scoreItem);
            _EnemyPrevScore++;
        }

        foreach (GameObject gameObject in _PlayerScores)
            gameObject.transform.Rotate(0, 60 * Time.deltaTime, 0);

        foreach (GameObject gameObject in _EnemyScores)
            gameObject.transform.Rotate(0, 60 * Time.deltaTime, 0);
    }

}
