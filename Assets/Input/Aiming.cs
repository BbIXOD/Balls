using System;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Transform _myTransform;
    [NonSerialized]public SpriteRenderer arrowRenderer;

    private const float RotOffset = -90;

    private void Awake()
    {
        _myTransform = transform;
        arrowRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Aim(Vector2 destination)
    {
        var desiredForward = destination - (Vector2)_myTransform.position;
        var desiredRot = Mathf.Atan2(desiredForward.y, desiredForward.x) * Mathf.Rad2Deg;
        _myTransform.rotation = Quaternion.Euler(0, 0, desiredRot + RotOffset);
    }
}
