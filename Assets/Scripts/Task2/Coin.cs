using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 20f;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _changedColor;

    private Color _baseColor;
    private Color _currentColor;

    private void Start()
    {
        _baseColor = _renderer.material.color;
        _currentColor = _renderer.material.color;
    }

    private void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }

    private void OnMouseDown()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        var color = _currentColor == _baseColor ? _changedColor : _baseColor;
        _renderer.material.color = color;
        _currentColor = color;
    }
}
