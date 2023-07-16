using UnityEngine;

public class Controllable : MonoBehaviour, IControllable
{
    public Vector2 Destination { private get; set; }

    public bool Pressed { set => PressCheck(value); }
    private bool _pressed;

    private Aiming _aiming;
    private Cannon _cannon;

    private void Awake()
    {
        _aiming = GetComponent<Aiming>();
        _cannon = GetComponent<Cannon>();
    }

    private void PressCheck(bool value)
    {
        if (_pressed != value && value == false) _cannon.Shoot();
        if (value) _aiming.Aim(Destination);
        _aiming.arrowRenderer.enabled = value;

        _pressed = value;

    }
}
