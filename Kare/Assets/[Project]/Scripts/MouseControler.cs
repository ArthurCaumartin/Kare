using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControler : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 15f;
    private Vector2 _pointerPos;
    private Camera _mainCamera;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    void Update()
    {
        Vector2 worldPos = _mainCamera.ScreenToWorldPoint(_pointerPos);
        transform.position =
        Vector2.Lerp(transform.position, worldPos, _moveSpeed * Time.deltaTime);
    }

    private void OnMouseMove(InputValue value)
    {
        _pointerPos = value.Get<Vector2>();
    }
}
