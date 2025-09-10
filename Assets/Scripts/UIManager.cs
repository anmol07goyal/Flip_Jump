using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _startGamePanel;
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;

    #region Instance

    public static UIManager Instance;

    #endregion

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _startGamePanel.SetActive(true);
        _endGamePanel.SetActive(false);
        SetScore();
        SetMaxScore();
    }

    public void OnClickStartGame()
    {
        _startGamePanel.SetActive(false);
        _highScoreText.gameObject.SetActive(false);
        GameManager.Instance.StartGame();
    }

    public void UpdateScoreTxt()
    {
        SetScore();
    }

    public void ShowEndGamePanel()
    {
        _endGamePanel.SetActive(true);
        _highScoreText.gameObject.SetActive(true);
        SetScore();
        SetMaxScore();
    }

    private void SetScore()
    {
        _scoreText.text = "Score : " + ScoreHandler.Instance.Score;
    }

    private void SetMaxScore()
    {
        _highScoreText.text = "High Score : " + ScoreHandler.Instance.MaxScore;
    }

    public void OnClickRestartGame()
    {
        GameManager.Instance.RestartGame();
    }
}
