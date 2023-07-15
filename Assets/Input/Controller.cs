using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Controls _controls;
    private IControllable _controllable;
    
    private void Awake()
    {
        _controls = new Controls();
        _controllable = GetComponent<IControllable>();
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
        _controllable.Destination = _controls.Ingame.PointerPlace.ReadValue<Vector2>();
        _controllable.Pressed = _controls.Ingame.PointerPressed.IsPressed();
    }
}
