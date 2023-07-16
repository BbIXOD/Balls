using UnityEngine;

public class Controller : MonoBehaviour
{
    private Controls _controls;
    private IControllable _controllable;
    private Camera _camera;
    
    private void Awake()
    {
        _controls = new Controls();
        _controllable = GetComponent<IControllable>();
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void FixedUpdate()
    {
        var dest = _controls.Ingame.PointerPlace.ReadValue<Vector2>();
        _controllable.Destination = _camera.ScreenToWorldPoint(dest);
        _controllable.Pressed = _controls.Ingame.PointerPressed.IsPressed();
    }
}
