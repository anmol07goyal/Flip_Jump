using UnityEngine;

public class BgMovingHandler : MonoBehaviour
{
    [SerializeField] private Material _bgMaterial;
    [SerializeField] private float _scrollSpeed = 0.5f;

    private Vector2 _textureOffset;

    private void Start()
    {
        _textureOffset = _bgMaterial.mainTextureOffset;
    }
    
    private void Update()
    {
        _textureOffset.x += Time.deltaTime * _scrollSpeed;

        // Use the modulo operator to wrap the offset between 0 and 1
        // This prevents the value from growing indefinitely
        _textureOffset.x %= 1.0f;

        _bgMaterial.mainTextureOffset = _textureOffset;
    }
}
