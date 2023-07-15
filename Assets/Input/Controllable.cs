using UnityEngine;

public class Controllable : MonoBehaviour, IControllable
{
    public Vector2 Destination { private get; set; }

    public bool Pressed { set => PressCheck(value); }
    private bool _pressed;

    private Aiming _aiming;

    private void Awake()
    {
        _aiming = GetComponent<Aiming>();
    }

    private void PressCheck(bool value)
    {
        if (_pressed != value && value == false) Shoot();
        if (value) _aiming.Aim(Destination);
        
        _pressed = value;

    }

    private void Shoot()
    {
        
    }
}
