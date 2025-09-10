using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool StartGame => _startGame;

    private bool _startGame;

    #region GameObjects

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _endGamePanel;

    #endregion

    #region Instance

    public static GameManager Instance;

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
        Time.timeScale = 0f;
    }

    public void OnClickStartGame()
    {
        _startGame = true;

        _player.SetActive(true);

        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        _endGamePanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
