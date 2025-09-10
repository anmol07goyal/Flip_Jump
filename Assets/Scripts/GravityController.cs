using System.Collections;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private float _gravityScale = 1f;
    [SerializeField] private float _invertedGravityScale = -1f;
    private bool _isGravityNormal = true;

    [SerializeField] private float _slowDownTime = 1f;

    private PlayerControls _playerControls;

    private void Awake()
    {
        _playerControls = new PlayerControls();
        _playerControls.Player.ClickOrTouch.performed += ctx => InvertGravity();
        _rb.gravityScale = _gravityScale;
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void InvertGravity()
    {
        _isGravityNormal = !_isGravityNormal;
        _rb.gravityScale = _isGravityNormal ? _gravityScale : _invertedGravityScale;

        // Flip the player's sprite and collider to match the new gravity
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            StartCoroutine(GameOverSeq());
        }
    }

    private IEnumerator GameOverSeq()
    {
        // Disable player controls
        _playerControls.Disable();

        float currentTime = 0f;

        while (currentTime < _slowDownTime)
        {
            currentTime += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(1f, 0f, currentTime / _slowDownTime);
            yield return null;
        }

        Time.timeScale = 0;

        GameManager.Instance.EndGame();
    }
}
