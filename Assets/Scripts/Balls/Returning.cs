using System;
using UnityEngine;

public class Returning : MonoBehaviour
{
    private Bullet _bullet;
    private Transform _myTransform;

    private const float LerpSpeed = 10f,
        MinDistance = 0.1f;

    public Vector3 Destination { set; private get; }

    private void Awake()
    {
        _myTransform = transform;
    }

    private void FixedUpdate()
    {
        if ((_myTransform.position - Destination).magnitude < MinDistance)
        {
            _myTransform.position = Destination;
            SingletonsHandler.cannon.BulletCount++;
            enabled = false;
            return;
        }
        
        _myTransform.position =
            Vector3.Lerp(_myTransform.position, Destination, LerpSpeed * Time.fixedDeltaTime);
    }
}
