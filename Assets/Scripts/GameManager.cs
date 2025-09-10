using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region GameObjects

    [SerializeField] private GameObject _player;

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

    public void StartGame()
    {
        _player.SetActive(true);

        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        ScoreHandler.Instance.SaveMaxScore();
        UIManager.Instance.ShowEndGamePanel();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
