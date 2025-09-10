using UnityEngine;

public class Spike : MonoBehaviour
{
    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }

    [SerializeField] private float _moveSpeed = 5f;
     
    private void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpikeDestroyer"))
        {
            // Deactivate the spike object and back to pool
            this.gameObject.SetActive(false);
        }
    }
}
