using UnityEngine;

public class BgMovingHandler : MonoBehaviour
{
    [SerializeField] private Material _bgMaterial;
    [SerializeField] private Material _roadMaterial;

    [SerializeField] private float _scrollSpeed = 0.5f;

    private Vector2 _bgTextureOffset;
    private Vector2 _roadTextureOffset;

    private void Start()
    {
        _bgTextureOffset = _bgMaterial.mainTextureOffset;
        _roadTextureOffset = _roadMaterial.mainTextureOffset;
    }
    
    private void Update()
    {
        _bgTextureOffset.x += Time.deltaTime * _scrollSpeed;
        _roadTextureOffset.x += Time.deltaTime * _scrollSpeed;

        // Use the modulo operator to wrap the offset between 0 and 1
        // This prevents the value from growing indefinitely
        _bgTextureOffset.x %= 1.0f;
        _roadTextureOffset.x %= 1.0f;

        _bgMaterial.mainTextureOffset = _bgTextureOffset;
        _roadMaterial.mainTextureOffset = _roadTextureOffset;
    }
}
