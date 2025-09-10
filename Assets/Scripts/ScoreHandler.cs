using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler Instance;

    public int Score => _score;
    private int _score = 0;

    public int MaxScore => _maxScore;
    private int _maxScore = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        GetMaxScore();
    }

    private void GetMaxScore()
    {
        _maxScore = PlayerPrefs.GetInt("MaxScore", 0);
        //UIManager.Instance.SetScoreAtStart();
    }

    public void UpdateScore()
    {
        _score++;
        UIManager.Instance.UpdateScoreTxt();
    }

    public void SaveMaxScore()
    {
        if (_score > _maxScore)
            _maxScore = _score;

        PlayerPrefs.SetInt("MaxScore", _maxScore);
    }
}
